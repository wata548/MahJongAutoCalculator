namespace MahJongAutoCalculator;

public enum WaitType {
	DoubleFace,
	DoubleHead,
	NoMiddle,
	SingleFace,
	SingleHead,
	Except,
}

public class Body: ICardCollection {

	public readonly bool IsStraight;
	public readonly bool IsFour;
	public bool IsOpen { get; set; }
	public readonly Card StandardCard;

	public static Body Four(Card pStandardCard) => new(pStandardCard);
	public static Body Triple(Card pStandardCard) => new(pStandardCard, false);
	public static Body Straight(Card pStandardCard) => new(pStandardCard, true);
	
	//Four card
	private Body(Card pStandardCard) {
		IsFour = true;
		StandardCard = pStandardCard;
	}
	
	//Straight or Triple
	private Body(Card pStandardCard, bool pIsStraight) {
		StandardCard = pStandardCard;
		IsStraight = pIsStraight;
		IsFour = false;
	}

	public WaitType GetWaitType(Card pLast) {
		if (!IsStraight) {
			if (pLast.CompareTo(StandardCard) == 0) return WaitType.DoubleHead;
			return WaitType.Except;
		}
		if (pLast is not NumberCard last) return WaitType.Except;
		var standard = (StandardCard as NumberCard)!;
		var delta = last.Number - standard.Number;
		if (delta is < 0 or > 2) return WaitType.Except;
		if (delta == 1) return WaitType.NoMiddle;
		if (delta == 0 && standard.Number == 1) return WaitType.SingleFace;
		if (delta == 2 && standard.Number == 9) return WaitType.SingleFace;
		return WaitType.DoubleFace;
	}
	
	public int GetFu(Setting _) {
		if (IsStraight) return 0;
		var v = 2;
		if (StandardCard is not NumberCard { Type: CardType.Middle })
			v *= 2;
		if (!IsOpen) v *= 2;
		if (IsFour) v *= 4;
		return v;
	}
	
	public override string ToString() {
		var suffix = IsOpen ? '-' : '+';
		if (IsStraight) return $"{suffix} {StandardCard} ~ {(StandardCard as NumberCard)!.Number + 2}";
		return $"{suffix} {StandardCard} x {(IsFour ? 4 : 3)}";
	}
}