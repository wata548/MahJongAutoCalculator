namespace MahJongAutoCalculator.SpecialForm;

public class SevenHead: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        var cnt = 0;
        Card last = null;
        foreach (var card in pHands) {
            if (last == null) {
                cnt = 1;
                last = card;
                continue;
            }

            if (last.Equals(card)) {
                cnt++;
                if (cnt > 2) return pScore;
            }
            else {
                if (cnt < 2) return pScore;
                cnt = 1;
                last = card;
            }
        }
        pScore.Lock = true;
        pScore.Set(pFu: 25);
        pScore.Add(pHan: 2);
        return pScore;
    }
}