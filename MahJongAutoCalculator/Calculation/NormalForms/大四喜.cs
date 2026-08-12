namespace MahJongAutoCalculator.NormalForms;

public class 大四喜: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Bodies.Count(body => body.StandardCard.Type == CardType.Wind);
        if (cnt >= 4) {
            ApplyForm(pScore, 2, true);
        }
        return pScore;  
    }
}