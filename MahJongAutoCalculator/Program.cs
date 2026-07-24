using System.Diagnostics;

namespace MahJongAutoCalculator;

public class Program {
    public static void Main() {
        /*var hands = new List<Card>() {
            new NumberCard(NumberType.Money, 1, false, false),
            new NumberCard(NumberType.Money, 1, false, false),
            new LetterCard(LetterType.White, false),
            new NumberCard(NumberType.Money, 1, false, false),
            new NumberCard(NumberType.Money, 1, false, false),
            new LetterCard(LetterType.White, false),
            new NumberCard(NumberType.Money, 2, false, false),
            new NumberCard(NumberType.Money, 2, false, false),
            new LetterCard(LetterType.White, false),
            new NumberCard(NumberType.Money, 3, false, false),
            new NumberCard(NumberType.Money, 3, false, false),
            new LetterCard(LetterType.White, false),
            new NumberCard(NumberType.Money, 4, false, false),
            new NumberCard(NumberType.Money, 4, false, false),
            new NumberCard(NumberType.Money, 4, false, false),
            new NumberCard(NumberType.Money, 4, false, false),
        };*/
        var hands = new List<Card>() {
            new NumberCard(NumberType.Money, 1, false, false),
            new NumberCard(NumberType.Money, 1, false, false),
            new NumberCard(NumberType.Money, 1, false, false),
            new NumberCard(NumberType.Money, 2, false, false),
            new NumberCard(NumberType.Money, 3, false, false),
            new NumberCard(NumberType.Money, 4, false, false),
            new NumberCard(NumberType.Money, 5, false, false),
            new NumberCard(NumberType.Money, 6, false, false),
            new NumberCard(NumberType.Money, 7, false, false),
            new NumberCard(NumberType.Money, 8, false, false),
            new NumberCard(NumberType.Money, 9, false, false),
            new NumberCard(NumberType.Money, 9, false, false),
            new NumberCard(NumberType.Money, 9, false, false),
            new NumberCard(NumberType.Money, 9, false, false),
        };
		var orderedHand = hands.OrderBy(card => card, new CardComparer());
        Console.WriteLine(Separator.Separate(orderedHand));
        
    }

    private float BenchMaking(IOrderedEnumerable<Card> pHands, int pAmount) {
        var timer = new Stopwatch();
        timer.Start();
        while (pAmount --> 0) {
            Separator.Separate(pHands);
        }
        timer.Stop();
        return timer.ElapsedMilliseconds;
    }
}