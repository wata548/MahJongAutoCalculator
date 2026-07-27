namespace MahJongAutoCalculator.NormalForms;

public class 一気通貫: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var init = false;
        var type = default(NumberType);
        var cnt = 0;
        foreach (var body in pHands.Bodies) {
            if(!body.IsStraight) continue;
            var number = (body.StandardCard as NumberCard)!;
            if (!init) {
                type = number.NumberType;
                init = true;
                continue;
            }
            if (number.NumberType != type) {
                type = number.NumberType;
                cnt = 0;
            }

            if (number.Number == 1 + cnt * 3 && ++cnt == 3) {
                ApplyForm(pScore, pSetting.HaveCried ? 1 : 2);
                pScore.Add(pSetting.HaveCried ? 1 : 2);
                return pScore;
            }
        }

        return pScore;
    }
}