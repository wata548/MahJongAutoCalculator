namespace MahJongAutoCalculator.SpecialForms;

public class 嶺上開花: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pSetting is { IsOpenInKingTable: true }) {
            ApplyForm(pScore);
            pScore.Add(1);
        }

        return pScore;
    }
}