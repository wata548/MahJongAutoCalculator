namespace MahJongAutoCalculator.NormalForms;

public class 小四喜: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Bodies.Count(body => body.StandardCard.Type == CardType.Wind);
        if (cnt >= 3 && pHands.Head.StandardCard.Type == CardType.Wind) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}