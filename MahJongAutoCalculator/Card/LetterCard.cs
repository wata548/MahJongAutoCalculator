public class LetterCard(LetterType pType): Card {
    public LetterType LetterType { get; private set; } = pType;
    protected override int OrderNumber => 2;
    public override CardType Type => CardType.Letter; 
    public override bool IsGreen => LetterType == LetterType.Bloom;
    //==================================================||Methods 
    public override bool Equals(Card? pOther) {
        if (pOther is not LetterCard letter) return false;
        return letter.LetterType == LetterType;
    }

    public override void MoveNext() {
        var next = (int)LetterType + 1;
        if (next > (int)LetterType.Middle) next = 0;
        LetterType = (LetterType)next;
    }

    protected override int CompareToSameType(Card pOther) {
        return LetterType.CompareTo((pOther as LetterCard)!.LetterType);
    }

    public override string ToString() => LetterType.ToString();
}