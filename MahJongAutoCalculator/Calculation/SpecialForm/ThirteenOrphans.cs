namespace MahJongAutoCalculator.SpecialForm;

public class ThirteenOrphans: SpecialForm {
    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, Setting pSetting) {
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
        
        //contain double yakuman(waiting 13 cards)
        pScore.AddYakuman(pLastCard.Equals(shootCard) ? 2 : 1);
        return pScore;
    }
}