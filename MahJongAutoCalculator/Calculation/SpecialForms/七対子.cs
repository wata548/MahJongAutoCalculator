namespace MahJongAutoCalculator.SpecialForms;

public class 七対子: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
        if (pHaveForm) return pScore;
        var cnt = 0;
        Card last = null;
        foreach (var card in pHands) {
            if (last == null) {
                cnt = 1;
                last = card;
                continue;
            }

            if (last.Equals(card)) cnt++;
            else {
                if (cnt % 2 == 1) return pScore;
                cnt = 1;
                last = card;
            }
        }
        if (cnt % 2 == 1) return pScore;
        ApplyForm(pScore, 2);
        pScore.Set(pFu: 25);
        pScore.FuLock = true;
        return pScore;
    }
}