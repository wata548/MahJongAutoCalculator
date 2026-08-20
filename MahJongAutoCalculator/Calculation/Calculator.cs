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
		
	public Score Calc(Setting pSetting, IEnumerable<Card> pCryHands, IEnumerable<Card> pHands, IEnumerable<Card> pDoras, Card pLastCard) {
		var haveCried = pCryHands.Count() > 0;
		pSetting = pSetting with { HaveCried = haveCried };
		
		var score = new Score(ContainCount);
		score.Add(pFu: 20);
		if(!pSetting.IsRon) score.Add(pFu: 2);
		else if(!pSetting.HaveCried) score.Add(pFu: 10);
		
		var comp = new CardComparer();
		var hands = pHands.OrderBy(card => card, comp);
		var fullHands = pHands.Union(pCryHands).OrderBy(card => card, comp);
		var form = Separator.Separate(pCryHands, hands);
		score.Add(pFu: form?.GetFu(pSetting, pLastCard) ?? 0);
		if (form is not null) {
			Console.Write(form);
			score = _normalForms.Aggregate(score,
				(current, checkForm) => checkForm.Calc(current, form, pLastCard, pSetting)
			);	
		}
		score.CeilFu();
		
		score = _specialForms.Aggregate(score, 
			(current, form) => form.Calc(current, fullHands, pLastCard, pSetting)
		);

		var red = fullHands.Count(card => card is NumberCard { IsRed: true }); return score;
	}
}