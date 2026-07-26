namespace MahJongAutoCalculator.SpecialForms;

public class 混一色: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
        var init = false;
        NumberType type = default;
        foreach (var card in pHands) {
            if (card is not NumberCard number) continue;
            if (!init) {
                type = number.NumberType;
                continue;
            }

            if (number.NumberType != type)
                return pScore;
            
        }
        ApplyForm(pScore);
        pScore.Add(pSetting.HaveCried ? 2 : 3);
        return pScore;
    }
}