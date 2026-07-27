namespace MahJongAutoCalculator.SpecialForms;

public abstract class SpecialForm: IForm {
    public string Name => GetType().Name;
    public abstract Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting);
    protected void ApplyForm(Score pScore, int pAmount, bool pIsYakuman = false, string pPrefix = "", string pSuffix = "") {
         pScore.ApplyForm(pPrefix + Name + pSuffix, pAmount, pIsYakuman);
    }
}