public class NumberCard(NumberType pType, int pNumber, bool pIsRed): Card {
    public readonly NumberType NumberType = pType;
    public int Number { get; private set; } = pNumber;
    public readonly bool IsRed = pIsRed;
    protected override int OrderNumber => 1;

    public override CardType Type =>
        Number is > 1 and < 9 ? CardType.Middle : CardType.Head;
    public override bool IsGreen => NumberType == NumberType.Bamboo && Number is 2 or 3 or 4 or 6 or 8;
    
    //==================================================||Methods 
    public override void MoveNext() {
        Number++;
        if (Number == 10) Number = 1;
    }

    public override bool Equals(Card? pOther) {
        if (pOther is not NumberCard number) return false;
        return number.NumberType == NumberType && number.Number == Number;
    }

    protected override int CompareToSameType(Card pOther) {
        var number = (pOther as NumberCard)!;
        var type = NumberType.CompareTo(number.NumberType);
        return type == 0
            ? Number.CompareTo(number.Number)
            : type;
    }

    public override string ToString() => $"{NumberType}-{Number}";
}