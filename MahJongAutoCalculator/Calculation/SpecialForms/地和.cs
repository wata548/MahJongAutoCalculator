namespace MahJongAutoCalculator.SpecialForms;

public class 地和: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pSetting.IsParent) return pScore;
        if (pSetting is { IsFirstTurn: true, IsRon: false }) {
            ApplyForm(pScore, true);
            pScore.AddYakuman(1);
        }

        return pScore;
    }
}