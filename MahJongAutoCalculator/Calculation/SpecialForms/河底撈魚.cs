namespace MahJongAutoCalculator.SpecialForms;

public class 河底撈魚: SpecialForm {

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pSetting is { IsLastCard: false, IsRon: true }) {
            ApplyForm(pScore, 1);
            pScore.Add(1);
        }
        return pScore;
    }
}