using System.Collections;

namespace MahJongAutoCalculator;

public abstract class CardCollection(IEnumerable<Card> pCards) : IEnumerable<Card> {
	protected readonly IEnumerable<Card> _cards = pCards;

	public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();
	public IEnumerable<Card> Cards1 => _cards;

	 IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}

public class Body: CardCollection {

	public readonly bool IsStraight;
	public Body(IEnumerable<Card> pCards): base(pCards) {
		var collection = pCards
			.OrderBy(card => card is NumberCard number ? number.Number : 0)
			.ToList();
		if (collection.Count != 3) throw new Exception($"Body size must be 3({collection.Count}");
		
		//check triple
		var first = collection[0];
		var isTriple = first.Equals(collection[1]) && first.Equals(collection[2]);
		if (isTriple) return;
		
		//check straight
		var exception = new Exception($"This collection can make body: {string.Join(", ", collection)}");
		if (collection[0] is not NumberCard firstNumber) throw exception;
		var isStraight = IsNext(firstNumber, collection[1], exception)
			&& IsNext(firstNumber, collection[2], exception);
		if (!isStraight) throw exception;
		IsStraight = true;

		bool IsNext(NumberCard pCard1, Card pCard2, Exception pException) {
			if (pCard2 is not NumberCard number)
				throw pException;
			return number.NumberType == pCard1.NumberType && pCard1.Number + 1 == number.Number;
		}
	}
	
}

public class Head: CardCollection {
	public Head(IEnumerable<Card> pCards): base(pCards) {
		if (pCards.Count() != 2) throw new Exception($"Head size must be 2({pCards.Count()}");
		
	}
}