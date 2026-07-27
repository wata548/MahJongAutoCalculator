using System.Reflection;
using MahJongAutoCalculator.NormalForms;
using MahJongAutoCalculator.SpecialForms;

namespace MahJongAutoCalculator;

public class Calculator {
	private readonly IReadOnlyList<SpecialForm> _specialForms;
	private readonly IReadOnlyList<NormalForm> _normalForms;

	public Calculator() {
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
		
	public Score Calc(Setting pSetting, IEnumerable<Card> pHands, IEnumerable<Card> pDoras, Card pLastCard) {
		//TODO: calculate Fu
		var haveCried = pHands.Count(card => card.IsRotated) - (pSetting.IsRon ? 1 : 0) != 0;
		pSetting = pSetting with { HaveCried = haveCried };
		
		var score = new Score();
		var hands = pHands.OrderBy(card => card, new CardComparer());
		var form = Separator.Separate(hands);
		if (form is not null) {
			score = _normalForms.Aggregate(score,
				(current, checkForm) => checkForm.Calc(current, form, pLastCard, pSetting)
			);	
		}
		
		score = _specialForms.Aggregate(score, 
			(current, form) => form.Calc(current, hands, pLastCard, pSetting)
		);
        
		//TODO: Calc doras
		return score;
	}
}