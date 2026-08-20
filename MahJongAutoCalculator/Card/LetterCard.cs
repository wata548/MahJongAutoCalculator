public class LetterCard(LetterType pType): Card {
    public readonly LetterType LetterType = pType;
    protected override int OrderNumber => 2;
    public override CardType Type => CardType.Letter; 
    public override bool IsGreen => LetterType == LetterType.Bloom;
    //==================================================||Methods 
    public override bool Equals(Card? pOther) {
        if (pOther is not LetterCard letter) return false;
        return letter.LetterType == LetterType;
    }

    protected override int CompareToSameType(Card pOther) {
        return LetterType.CompareTo((pOther as LetterCard)!.LetterType);
    }

    public override string ToString() => LetterType.ToString();
}