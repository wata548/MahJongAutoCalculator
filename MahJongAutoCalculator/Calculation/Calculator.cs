using System.Reflection;
using MahJongAutoCalculator.DefaultForm;
using MahJongAutoCalculator.SpecialForm;

namespace MahJongAutoCalculator;

public class Calculator {
	private readonly IReadOnlyList<SpecialForm.SpecialForm> _specialForms;
	private readonly IReadOnlyList<NormalForm> _normalForms;

	public Calculator() {
		var asm = Assembly.GetExecutingAssembly();
		var targets = asm.GetTypes()
			.Where(type => type is { IsAbstract: false, IsInterface: false }
			               && type.IsAssignableTo(typeof(IForm))
			);
		_specialForms = targets
			.Where(type => type.IsAssignableTo(typeof(SpecialForm.SpecialForm)))
			.Select(type => (Activator.CreateInstance(type) as SpecialForm.SpecialForm)!)
			.ToList();
		_normalForms = targets 
			.Where(type => type.IsAssignableTo(typeof(NormalForm)))
			.Select(type => (Activator.CreateInstance(type) as NormalForm)!)
			.ToList();
	}
		
	public Score Calc(Setting pSetting, IEnumerable<Card> pHands, IEnumerable<Card> pDoras, Card pLastCard) {
		var score = new Score();
		var hands = pHands.OrderBy(card => card, new CardComparer());

		score = _specialForms.Aggregate(score, 
			(current, form) => form.Calc(current, hands, pLastCard, pSetting)
		);

		if (score is not { Fu: 0, Han: 0 }) {
			//TODO: Skip find form in default forms(just calc doras)
			return score;
		}

		var form = Separator.Separate(hands);
		score = _normalForms.Aggregate(score,
			(current, checkForm) => checkForm.Calc(current, form, pLastCard, pSetting)
		);
		//TODO: Calc doras
		return score;
	}
}