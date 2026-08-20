namespace MahJongAutoCalculator.SpecialForms;

public class 海底撈月: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
        if (pSetting is { IsLastCard: true, IsRon: false }) {
            ApplyForm(pScore, 1);
        }

        return pScore;
    }
}