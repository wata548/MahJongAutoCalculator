namespace MahJongAutoCalculator.NormalForms;

public class WindForm: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var seatWind = pHands.Bodies.Any(body =>
            body.StandardCard is WindCard wind && wind.Direction == pSetting.SeatWind);
        var roundWind = pHands.Bodies.Any(body =>
                    body.StandardCard is WindCard wind && wind.Direction == pSetting.RoundWind);
        if (seatWind && roundWind) {
            pScore.ApplyForm("連風牌");
            pScore.Add(2);
        }
        else if (seatWind) {
            pScore.ApplyForm("自風牌");
            pScore.Add(1);
        }
        else if (roundWind) {
            pScore.ApplyForm("場風牌");
            pScore.Add(1);
        }
        return pScore;
    }
}