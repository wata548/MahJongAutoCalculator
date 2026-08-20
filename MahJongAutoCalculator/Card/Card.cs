public abstract class Card: IEquatable<Card>, IComparable<Card> {
    public static int Compare(Card pLhs, Card pRhs) => pLhs.CompareTo(pRhs);
    
    protected abstract int OrderNumber { get; }
    public abstract CardType Type { get; }
    public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
    public abstract bool IsGreen { get; }
    
    //==================================================||Methods 
    public abstract bool Equals(Card? pOther);

    protected abstract int CompareToSameType(Card pOther);
    
    public int CompareTo(Card? pOther) {
        if (ReferenceEquals(this, pOther)) return 0;
        if (pOther is null) return 1;
        if (GetType() != pOther.GetType()) return OrderNumber.CompareTo(pOther.OrderNumber);
        return CompareToSameType(pOther);

    }
}