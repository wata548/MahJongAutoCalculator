namespace MahJongAutoCalculator.SpecialForms;

public class Rich: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting,
        bool pHaveForm) {
        if (pSetting.IsRich)
            pScore.ApplyForm("立直", 1);
        if (pSetting.IsOneShot)
            pScore.ApplyForm("一発", 1);

        return pScore;
    }
}