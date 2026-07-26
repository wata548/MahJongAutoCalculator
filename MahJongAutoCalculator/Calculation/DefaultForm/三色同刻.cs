namespace MahJongAutoCalculator.DefaultForm;

public class 三色同刻: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = new int[9];
        var targets = pHands.Bodies
            .Where(body => !body.IsStraight && body.StandardCard is NumberCard)
            .Select(body => (body.StandardCard as NumberCard)!)
            .Distinct();
        foreach (var target in targets) {
            if (++cnt[target.Number] != 3) continue;
            ApplyForm(pScore);
            pScore.Add(pHan: 2);
            return pScore;
        }
        return pScore;
    }
}