namespace MahJongAutoCalculator.NormalForms;

public class 四槓子: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pHands.Bodies.All(body => body.IsFour)) {
            ApplyForm(pScore, 1, true);
        }
        return pScore;
    }
}