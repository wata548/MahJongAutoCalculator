using System.Collections;

namespace MahJongAutoCalculator;

public class Body {

	public readonly bool IsStraight;
	public readonly bool IsFour;
	public readonly bool IsOpen;
	public readonly Card StandardCard;

	public static Body Four(Card pStandardCard, bool pIsOpen) => new(pStandardCard, pIsOpen);
	public static Body Triple(Card pStandardCard, bool pIsOpen) => new(pStandardCard, false, pIsOpen);
	public static Body Straight(Card pStandardCard, bool pIsOpen) => new(pStandardCard, true, pIsOpen);
	
	//Four card
	private Body(Card pStandardCard, bool pIsOpen) {
		IsFour = true;
		StandardCard = pStandardCard;
		IsOpen = pIsOpen;
	}
	
	//Straight or Triple
	private Body(Card pStandardCard, bool pIsStraight, bool pIsOpen) {
		StandardCard = pStandardCard;
		IsStraight = pIsStraight;
		IsFour = false;
		IsOpen = pIsOpen;
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