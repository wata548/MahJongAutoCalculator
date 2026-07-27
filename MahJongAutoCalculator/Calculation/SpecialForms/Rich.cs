namespace MahJongAutoCalculator.SpecialForms;

public class Rich: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        if (pSetting.IsRich) {
            pScore.ApplyForm("立直", 1);
            pScore.Add(1);
        }

        if (pSetting.IsOneShot) {
            pScore.ApplyForm("一発", 1);
            pScore.Add(1);
        }

        return pScore;
    }
}