namespace MahJongAutoCalculator.NormalForms;

public class 一盃口: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        if (pSetting is { HaveCried: true }) return pScore;
        
        var targets = pHands.Bodies.Where(body => body.IsStraight);
        Card last = null;
        foreach (var target in targets) {
            if (last == null) {
                last = target.StandardCard;
                continue;
            }
            if(!last.Equals(target.StandardCard)) continue;
            
            ApplyForm(pScore, 1);
            pScore.Add(1);
            break;
        }
        return pScore;
    }
}