namespace MahJongAutoCalculator.SpecialForms;

public class 赤ドラ: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        var cnt = pHands.Count(card => card is NumberCard number && number.IsRed);
        if (cnt > 0)
            ApplyForm(pScore, cnt);
        return pScore;
    }
}