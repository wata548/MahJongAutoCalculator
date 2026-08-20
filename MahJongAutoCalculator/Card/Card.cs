using System.Runtime.InteropServices.Swift;
using System.Xml.XPath;

public abstract class Card: IEquatable<Card>, IComparable<Card> {
	public static int Compare(Card pLhs, Card pRhs) => pLhs.CompareTo(pRhs);
    
	protected abstract int OrderNumber { get; }
	public abstract CardType Type { get; }
	public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
	public abstract bool IsGreen { get; }
    
	//==================================================||Methods 
	public abstract bool Equals(Card? pOther);
	public abstract void MoveNext();
	protected abstract int CompareToSameType(Card pOther);

	public static IEnumerable<Card> Parse(string pContext) {
		var result = new List<Card>();
		var numbers = new List<int>();
		foreach (var c in pContext) {
			if (char.IsDigit(c)) {
				numbers.Add(c - '0');
				continue;
			}

			NumberType? type = c switch {
				'm' => NumberType.Money,
				's' => NumberType.Bamboo,
				'p' => NumberType.Wheel,
				_ => null
			};
			if (type == null || numbers.Count == 0) {
				 result.Add(c switch {
					'w' => new WindCard(WindDirection.West),
					'e' => new WindCard(WindDirection.East),
					's' => new WindCard(WindDirection.South),
					'n' => new WindCard(WindDirection.North),
					'm' => new LetterCard(LetterType.Middle),
					'h' => new LetterCard(LetterType.White),
					'g' => new LetterCard(LetterType.Bloom),
				});
				 continue;
			}

			foreach (var number in numbers)
				result.Add(new NumberCard((NumberType)type, number, false));
			numbers.Clear();
		}

		return result;
	}
    
	public int CompareTo(Card? pOther) {
		if (ReferenceEquals(this, pOther)) return 0;
		if (pOther is null) return 1;
		if (GetType() != pOther.GetType()) return OrderNumber.CompareTo(pOther.OrderNumber);
		return CompareToSameType(pOther);
	}
}