namespace MahJongAutoCalculator.NormalForms;

public class 三槓子: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pHands.Bodies.Count(body => body.IsFour) >= 3) {
            ApplyForm(pScore, 2);
            pScore.Add(2);
        }
        return pScore;
    }
}