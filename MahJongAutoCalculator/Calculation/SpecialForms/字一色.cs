namespace MahJongAutoCalculator.SpecialForms;

public class 字一色: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pHands.All(card => (card.Type & CardType.LetterMask) != CardType.None)) {
            ApplyForm(pScore, 1, true);
            pScore.AddYakuman(1);
        }

        return pScore;
    }
}