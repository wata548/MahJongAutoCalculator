namespace MahJongAutoCalculator.NormalForms;

public class 大三元: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Bodies.Where(body => body.StandardCard is LetterCard)
            .Select(body => body.StandardCard)
            .Distinct()
            .Count();
        if (cnt == 3) {
            ApplyForm(pScore, 1, true);
            pScore.AddYakuman(1);
        }

        return pScore;
    }
}