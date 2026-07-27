namespace MahJongAutoCalculator.NormalForms;

public abstract class NormalForm: IForm {
    public virtual string Name => GetType().Name;
    public abstract Score Calc(Score pScore, Form pHands, Card pLastCard, Setting pSetting);

    protected void ApplyForm(Score pScore, int pAmount, bool pIsYakuman = false, string pPrefix = "", string pSuffix = "") {
         pScore.ApplyForm(pPrefix + Name + pSuffix, pAmount, pIsYakuman);
    }
}