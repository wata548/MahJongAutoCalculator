namespace MahJongAutoCalculator.SpecialForm;

public abstract class SpecialForm {
    public abstract Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting);
}