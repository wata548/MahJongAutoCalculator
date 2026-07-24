using System.Collections;

namespace MahJongAutoCalculator;

public class Body {

	public readonly bool IsStraight;
	public readonly bool IsFour;
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

	public override string ToString() {
		if (IsStraight) return $"{StandardCard} ~ {(StandardCard as NumberCard)!.Number + 2}";
		return $"{StandardCard} x {(IsFour ? 4 : 3)}";
	}
}

public class Head {
	public readonly Card StandardCard;
	public Head(Card pStandardCard) => StandardCard = pStandardCard;
	public override string ToString() => $"{StandardCard} x 2";
}