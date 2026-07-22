namespace MahJongAutoCalculator.SpecialForm;

public abstract class SpecialForm {
    public abstract Score Calc(Score pScore, IEnumerable<Card> pHands, Card pLastCard, Setting pSetting);
}