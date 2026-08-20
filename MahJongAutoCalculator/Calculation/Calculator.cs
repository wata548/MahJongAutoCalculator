using System.Diagnostics;
using System.Reflection;
using MahJongAutoCalculator.NormalForms;
using MahJongAutoCalculator.SpecialForms;

namespace MahJongAutoCalculator;

public class Calculator {
	private readonly IReadOnlyList<SpecialForm> _specialForms;
	private readonly IReadOnlyList<NormalForm> _normalForms;
	public bool ContainCount { get; set; }

	public Calculator(bool pContainCount = false) {
		ContainCount = pContainCount;
		var asm = Assembly.GetExecutingAssembly();
		var targets = asm.GetTypes()
			.Where(type => type is { IsAbstract: false, IsInterface: false }
				&& type.IsAssignableTo(typeof(IForm))
			);
		_specialForms = targets
			.Where(type => type.IsAssignableTo(typeof(SpecialForm)))
			.Select(type => (Activator.CreateInstance(type) as SpecialForm)!)
			.ToList();
		_normalForms = targets 
			.Where(type => type.IsAssignableTo(typeof(NormalForm)))
			.Select(type => (Activator.CreateInstance(type) as NormalForm)!)
			.ToList();
	}
		
	public Score Calc(Setting pSetting, IEnumerable<Card> pCryHands, IEnumerable<Card> pHands, IEnumerable<Card> pDoras, Card pLastCard, out Form pForm) {
		var haveCried = pCryHands.Count() > 0;
		pSetting = pSetting with { HaveCried = haveCried };
		
		var score = new Score(ContainCount);
		score.AddFu(20);
		if(!pSetting.IsRon) score.AddFu(2);
		else if(!pSetting.HaveCried) score.AddFu(10);
		
		var comparer = new CardComparer();
		var hands = pHands.OrderBy(card => card, comparer);
		var fullHands = pHands.Concat(pCryHands).OrderBy(card => card, comparer);
		var form = Separator.Separate(pCryHands, hands);
		pForm = form;
		
		score.AddFu(form?.GetFu(pSetting, pLastCard) ?? 0);
		if (form is not null) {
			Console.Write(form);
			score = _normalForms.Aggregate(score,
				(current, checkForm) => checkForm.Calc(current, form, pLastCard, pSetting)
			);	
		}
		score.CeilFu();
		
		score = _specialForms.Aggregate(score, 
			(current, specialForm) => specialForm.Calc(current, fullHands, pLastCard, pSetting, form != null)
		);
		
		CalcDora();
		return score;

		void CalcDora() {
			if(score.IsYakuman) return;
			if (score.Han == 0) return;
			
			var red = fullHands.Count(card => card is NumberCard { IsRed: true }); 
			if(red > 0)
				score.ApplyForm("赤ドラ", red);
		
			foreach (var dora in pDoras) {
				dora.MoveNext();
			}
			var handEnumerator = fullHands.GetEnumerator();
			var doraEnumerator = pDoras.OrderBy(card => card, comparer).GetEnumerator();
			var doraCnt = 0;
			if (!(handEnumerator.MoveNext() && doraEnumerator.MoveNext()))
				return;
			var stack = 0;
			while (true) {
				var comp = handEnumerator.Current.CompareTo(doraEnumerator.Current);
				if (comp == 0) {
					doraCnt++;
					stack++;
					while (true) {
						var temp = handEnumerator.Current;
						if (!handEnumerator.MoveNext()) goto ExitLoop;
						if (temp.CompareTo(handEnumerator.Current) == 0) {
							doraCnt++;
							stack++;	
						}
						else break;
					}
				}
				else if (comp < 0) {
					if (!handEnumerator.MoveNext()) break;
				}
				else {
					while (true) {
						var temp = doraEnumerator.Current;
						if (!doraEnumerator.MoveNext()) goto ExitLoop;
						if(temp.CompareTo(doraEnumerator.Current) == 0)
							doraCnt += stack;
						else {
							stack = 0;
							break;
						}
					}
				}
			}	
		ExitLoop:
			while (true) {
				var temp = doraEnumerator.Current;
				if (!doraEnumerator.MoveNext()) break;
				if(temp.CompareTo(doraEnumerator.Current) == 0)
					doraCnt += stack;
				else {
					stack = 0;
					break;
				}
			}
			
			if(doraCnt > 0)
				score.ApplyForm("ドラ", doraCnt);
			
			if(pSetting.NorthCnt > 0)
				score.ApplyForm("抜きドラ", pSetting.NorthCnt);
		}
	}
}