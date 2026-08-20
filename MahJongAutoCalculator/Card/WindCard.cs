public class WindCard(WindDirection pType) : Card {
    public readonly WindDirection Direction = pType;
    protected override int OrderNumber => 3;
    public override CardType Type => CardType.Wind;
    public override bool IsGreen => false;
    public override bool Equals(Card? pOther) {
        if (pOther is not WindCard wind) return false;
        return wind.Direction == Direction;
    }

    protected override int CompareToSameType(Card pOther) {
        return Direction.CompareTo((pOther as WindCard)!.Direction);
    }

    public override string ToString() => Direction.ToString();
}