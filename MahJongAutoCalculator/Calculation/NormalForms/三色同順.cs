namespace MahJongAutoCalculator.NormalForms;

public class 三色同順: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        var cnt = new int[9];
        var targets = pHands.Bodies
            .Where(body => body.IsStraight)
            .Select(body => (body.StandardCard as NumberCard)!);
        NumberCard prev = null;
        foreach (var target in targets) {
            if(prev is not null && prev.Equals(target)) continue;
            prev = target;
            if (++cnt[target.Number] != 3) continue;
            ApplyForm(pScore);
            pScore.Add(pSetting.HaveCried ? 1 : 2);
            return pScore;
        }
        return pScore;
    }
}