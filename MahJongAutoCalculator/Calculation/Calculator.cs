using System.Net.Mime;
using System.Reflection;

namespace MahJongAutoCalculator;

public class Calculator {
	private readonly IReadOnlyList<SpecialForm.SpecialForm> _specialForms;

	public Calculator() {
		var asm = Assembly.GetExecutingAssembly();
		_specialForms = asm.GetTypes()
			.Where(type => type is { IsAbstract: false, IsInterface: false }
			               && type.IsSubclassOf(typeof(SpecialForm.SpecialForm))
			)
			.Select(type => (Activator.CreateInstance(type) as SpecialForm.SpecialForm)!)
			.ToList();
	}
		
	public Score Calc(Setting pSetting, IEnumerable<Card> pHands, IEnumerable<Card> pDoras, Card pLastCard) {
		var score = new Score();
		var hands = pHands.ToList();
		hands.Sort();
		foreach (var form in _specialForms) {
			score = form.Calc(score, hands, pLastCard, pSetting);
		}

		if (score is { Fu: 0, Han: 0 }) {
			//TODO: Skip find form in default forms(just calc doras)
			return score;
		}

		//TODO: Calc score in default forms, doras
		return score;
	}
}