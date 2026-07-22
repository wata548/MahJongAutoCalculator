public abstract class Card(bool pIsRotated): IEquatable<Card>, IComparable<Card> {
    public abstract CardType Type { get; }
    public readonly bool IsRotated = pIsRotated;
    public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
    public abstract bool IsGreen { get; }
    
    //==================================================||Methods 
    public abstract bool Equals(Card? pOther);

    protected abstract int CompareToSameType(Card pOther);
    
    public int CompareTo(Card? pOther) {
        if (ReferenceEquals(this, pOther)) return 0;
        if (pOther is null) return 1;
        return CompareToSameType(pOther);

    }
}

public class NumberCard(NumberType pType, int pNumber, bool pIsRotated): Card(pIsRotated) {
    public readonly NumberType NumberType = pType;
    public readonly int Number = pNumber;
    public override CardType Type =>
        Number is > 1 and < 9 ? CardType.Middle : CardType.Head;
    public override bool IsGreen => NumberType == NumberType.Bamboo && Number is 2 or 3 or 4 or 6 or 8;
    
    //==================================================||Methods 
    public override bool Equals(Card? pOther) {
        if (pOther is not NumberCard number) return false;
        return number.NumberType == NumberType && number.Number == Number;
    }

    protected override int CompareToSameType(Card pOther) {
        if (pOther is not NumberCard number) return 1;
        var type = NumberType.CompareTo(number.NumberType);
        return type == 0
            ? Number.CompareTo(number.Number)
            : type;
    }

    public override string ToString() => $"{NumberType}{Number}";
}

public class LetterCard(LetterType pType, bool pIsRotated): Card(pIsRotated) {
    public readonly LetterType LetterType = pType;
    public override CardType Type => CardType.Letter; 
    public override bool IsGreen => LetterType == LetterType.Bloom;
    //==================================================||Methods 
    public override bool Equals(Card? pOther) {
        if (pOther is not LetterCard letter) return false;
        return letter.LetterType == LetterType;
    }

    protected override int CompareToSameType(Card pOther) {
        if (pOther is not LetterCard letter) return 1;
        return LetterType.CompareTo(letter.LetterType);
    }

    public override string ToString() => LetterType.ToString();
}

public class WindCard(WindDirection pType, bool pIsRotated) : Card(pIsRotated) {
    public readonly WindDirection Direction = pType;
    public override CardType Type => CardType.Wind;
    public override bool IsGreen => false;
    public override bool Equals(Card? pOther) {
        if (pOther is not WindCard wind) return false;
        return wind.Direction == Direction;
    }

    protected override int CompareToSameType(Card pOther) {
        if (pOther is not WindCard wind) return 1;
        return Direction.CompareTo(wind.Direction);
    }

    public override string ToString() => Direction.ToString();
} 