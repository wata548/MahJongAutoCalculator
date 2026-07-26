namespace MahJongAutoCalculator.NormalForms;

public class 四暗刻: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pSetting.HaveCried) return pScore;
        if (pHands.Bodies.All(body => !body.IsStraight)) {
            var isDouble = pLastCard.Equals(pHands.Head.StandardCard);
            ApplyForm(pScore, true, "", isDouble ? "単騎" : "");
            pScore.AddYakuman(isDouble ? 2 : 1);
        }

        return pScore;
    }
}