namespace MahJongAutoCalculator.SpecialForms;

public class 門前清自摸和: SpecialForm {
	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
		if (pSetting is { IsRon: false, HaveCried: false }) {
			ApplyForm(pScore, 1);
		}

		return pScore;
	}
}