namespace MahJongAutoCalculator.NormalForms;


public class 対々和: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pHands.Bodies.All(body => !body.IsStraight)) {
            ApplyForm(pScore, 2);
            pScore.Add(2);
        }
        return pScore;
    }   
}