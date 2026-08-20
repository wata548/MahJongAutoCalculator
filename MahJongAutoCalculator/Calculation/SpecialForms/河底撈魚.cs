namespace MahJongAutoCalculator.SpecialForms;

public class 河底撈魚: SpecialForm {

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
        if (pSetting is { IsLastCard: true, IsRon: true }) {
            ApplyForm(pScore, 1);
        }
        return pScore;
    }
}