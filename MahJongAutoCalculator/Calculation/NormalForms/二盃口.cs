namespace MahJongAutoCalculator.NormalForms;

public class 二盃口: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pSetting is { HaveCried: true }) return pScore;
        
        var targets = pHands.Bodies.Where(body => body.IsStraight);
        Card last = null;
        var cnt = 0;
        foreach (var target in targets) {
            if (last == null) {
                last = target.StandardCard;
                continue;
            }
            if(!last.Equals(target.StandardCard)) continue;
            cnt++;
            last = null;
        }
        if(cnt == 2) ApplyForm(pScore, 3);
        return pScore;
    }
}