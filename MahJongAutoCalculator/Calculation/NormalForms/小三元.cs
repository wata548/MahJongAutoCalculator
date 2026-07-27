namespace MahJongAutoCalculator.NormalForms;

public class 小三元: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Bodies.Count(body => body.StandardCard.Type == CardType.Letter);
        if (cnt >= 2 && pHands.Head.StandardCard.Type == CardType.Letter) {
            ApplyForm(pScore, 2);
            pScore.Add(2);
        }

        return pScore;  
    }
}