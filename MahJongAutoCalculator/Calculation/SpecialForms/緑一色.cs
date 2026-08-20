namespace MahJongAutoCalculator.SpecialForms;

public class 緑一色: SpecialForm {
	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
		if (pHands.All(card => card.IsGreen)) {
			ApplyForm(pScore, 1, true);
		}
		return pScore;
	}
}