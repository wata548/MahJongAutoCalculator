namespace MahJongAutoCalculator.NormalForms;

public class 三暗刻: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Bodies.Count(body => body is { IsStraight: false, IsOpen: false });
        if (cnt >= 3) {
            ApplyForm(pScore, 2);
            pScore.Add(2);
        }

        return pScore;
    }
}