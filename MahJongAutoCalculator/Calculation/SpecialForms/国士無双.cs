namespace MahJongAutoCalculator.SpecialForms;

public class 国士無双: SpecialForm {
    private const string DoubleSuffix = "十三面聽";
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting, bool pHaveForm) {
        Card shootCard = null;
        Card lastCard = null;
        foreach (var card in pHands ) {
            if (lastCard == null) {
                lastCard = card;
                continue;
            }

            if ((card.Type & CardType.Head) == CardType.None) 
                return pScore;
            if (lastCard.Equals(card)) {
                if (shootCard != null) return pScore;
                shootCard = card;
            }
            lastCard = card;
        }

        if (shootCard == null) return pScore;

        var isDouble = pLastCard.Equals(shootCard);
        ApplyForm(pScore, isDouble ? 2 : 1, true, "", isDouble ? DoubleSuffix : "");
        return pScore;
    }
}