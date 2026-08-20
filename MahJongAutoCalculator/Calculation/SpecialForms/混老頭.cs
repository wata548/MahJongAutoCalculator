namespace MahJongAutoCalculator.SpecialForms;

public class 混老頭: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
        var correct = pHands.All(card => (card.Type & CardType.Head) != CardType.None);
        if (correct) {
            ApplyForm(pScore, 2);
        }

        return pScore;
    }
}