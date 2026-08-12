namespace MahJongAutoCalculator.NormalForms;

public class 四暗刻: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pHands.Bodies.All(body => body is {IsStraight: false, IsOpen: false})) {
            var isDouble = pLastCard.Equals(pHands.Head.StandardCard);
            ApplyForm(pScore, isDouble ? 2 : 1, true, "", isDouble ? "単騎" : "");
        }

        return pScore;
    }
}