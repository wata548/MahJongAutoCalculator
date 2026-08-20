public class WindCard(WindDirection pType) : Card {
    public WindDirection Direction { get; private set; } = pType;
    protected override int OrderNumber => 3;
    public override CardType Type => CardType.Wind;
    public override bool IsGreen => false;
    public override bool Equals(Card? pOther) {
        if (pOther is not WindCard wind) return false;
        return wind.Direction == Direction;
    }

    public override void MoveNext() {
        var next = (int)Direction + 1;
        if (next > (int)WindDirection.North) next = 0;
        Direction = (WindDirection)next;
    }

    protected override int CompareToSameType(Card pOther) {
        return Direction.CompareTo((pOther as WindCard)!.Direction);
    }

    public override string ToString() => Direction.ToString();
}