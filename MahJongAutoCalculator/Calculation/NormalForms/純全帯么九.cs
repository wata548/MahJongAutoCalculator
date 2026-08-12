namespace MahJongAutoCalculator.NormalForms;

public class 純全帯么九: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var condition1 = pHands.Bodies.All(body =>
            body is 
                { IsStraight: true, StandardCard: NumberCard { Number: 7} } or 
                { StandardCard: NumberCard {Type: CardType.Head}}
        );
        if (condition1) {
            ApplyForm(pScore, pSetting.HaveCried ? 2 : 3);
        }
    
        return pScore;
    }
}