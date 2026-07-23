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
		pStandardCard = pStandardCard;
	}
	
	//Straight or Triple
	private Body(Card pStandardCard, bool pIsStraight) {
		StandardCard = pStandardCard;
		IsStraight = pIsStraight;
		IsFour = false;
	}
}

public class Head {
	public readonly Card StandardCard;
	public Head(Card pStandardCard) => StandardCard = pStandardCard;
}