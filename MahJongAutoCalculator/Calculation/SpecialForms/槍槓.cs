namespace MahJongAutoCalculator.SpecialForms;

public class 槍槓: SpecialForm {
	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
		if(pSetting.IsStealFour) ApplyForm(pScore, 1);
		return pScore;
	}
}