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