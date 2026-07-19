public abstract class Card{
    public abstract CardType Type { get; }
    public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
    public abstract bool IsGreen { get; } 
}

public class NumberCard(NumberType pType, int pNumber): Card {
    public readonly NumberType NumberType = pType;
    public readonly int Number = pNumber;
    public override CardType Type { get; } =
        pNumber is > 1 and < 9 ? CardType.Middle : CardType.Head;
    public override bool IsGreen => NumberType == NumberType.Bamboo && Number is 2 or 3 or 4 or 6 or 8;
}

public class LetterCard(LetterType pType): Card {
    public readonly LetterType LetterType = pType;
    public override CardType Type { get; } =
        pType > LetterType.North ? CardType.Letter : CardType.Wind;
    public override bool IsGreen => LetterType == LetterType.Bloom;
}