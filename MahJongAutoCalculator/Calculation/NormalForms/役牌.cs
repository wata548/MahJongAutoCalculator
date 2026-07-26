namespace MahJongAutoCalculator.NormalForms;

public class 役牌: NormalForm {
    public override Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting) {
        foreach (var body in pHands.Bodies) {
            if(body.IsStraight) continue; 
            if(body.StandardCard is not LetterCard letter) continue;
            ApplyForm(pScore, pSuffix: $" - {letter.LetterType}");
            pScore.Add(1);
        }
        return pScore;
    }
}