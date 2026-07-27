namespace MahJongAutoCalculator.SpecialForms;

public class 清老頭: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pHands.All(card => card.Type == CardType.Head)) {
            ApplyForm(pScore, 1, true);
            pScore.AddYakuman(1);
        }

        return pScore;
    }
}