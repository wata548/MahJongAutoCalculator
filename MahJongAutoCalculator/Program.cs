public abstract class Card{
    public abstract CardType Type { get; }
    public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
}

public class NumberCard(NumberType pType, int pNumber): Card {
    public readonly NumberType NumberType = pType;
    public readonly int Number = pNumber;
    public override CardType Type { get; } =
        pNumber is > 1 and < 9 ? CardType.Middle : CardType.Head;
}

public class LetterCard(LetterType pType): Card {
    public readonly LetterType LetterType = pType;
    public override CardType Type { get; } =
        pType > LetterType.North ? CardType.Letter : CardType.Wind;
}

public enum NumberType {
    Wheel,
    Money,
    Bamboo
}

public enum LetterType {
    East,
    South,
    West,
    North,
    White,
    Bloom,
    Middle,
}

[Flags]
public enum CardType {
    None       = 0b0000,
    Head       = 0b0001,
    Letter     = 0b0011,
    Wind       = 0b0111,
    LetterMask = 0b0110,
    Middle     = 0b1000,
}