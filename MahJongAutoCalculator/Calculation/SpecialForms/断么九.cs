namespace MahJongAutoCalculator.SpecialForms;

public class 断么九: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pHands.All(card => card.Type == CardType.Middle)) {
            ApplyForm(pScore, 1);
            pScore.Add(1);        
        }
        return pScore;
    }
}