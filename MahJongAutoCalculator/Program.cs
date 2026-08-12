using System.Diagnostics;

namespace MahJongAutoCalculator;

public class Program {
    public static void Main() {
        var setting = new Setting(
            true,
            WindDirection.East,
            WindDirection.West,
            0,
            true,
            false,
            false,
            true,
            false,
            false,
            true
        );

        var hands = Big();
        var calculator = new Calculator(true);
        var result = calculator.Calc(setting, hands, [], new LetterCard(LetterType.Bloom, true));
        Console.WriteLine(result);
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

    private static List<Card> SevenHead() => [
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
    ];
    private static List<Card> Big() => [
        new LetterCard(LetterType.White, false),
        new LetterCard(LetterType.White, false),
        new LetterCard(LetterType.White, false),
        new LetterCard(LetterType.Bloom, false),
        new LetterCard(LetterType.Bloom, false),
        new LetterCard(LetterType.Bloom, true),
        new LetterCard(LetterType.Middle, false),
        new LetterCard(LetterType.Middle, false),
        new WindCard(WindDirection.East, false),
        new WindCard(WindDirection.East, false),
        new WindCard(WindDirection.East, false),
        new NumberCard(NumberType.Wheel, 1, true, false),
        new NumberCard(NumberType.Wheel, 1, true, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
    ];
    private static List<Card> Test() => [
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Wheel, 2, false, false),
        new NumberCard(NumberType.Money, 2, false, false),
        new NumberCard(NumberType.Money, 2, false, false),
        new NumberCard(NumberType.Money, 2, false, false),
        new NumberCard(NumberType.Bamboo, 2, false, false),
        new NumberCard(NumberType.Bamboo, 2, false, false),
        new NumberCard(NumberType.Bamboo, 2, false, false),
        new NumberCard(NumberType.Bamboo, 4, false, false),
        new NumberCard(NumberType.Bamboo, 4, false, false),
        new NumberCard(NumberType.Bamboo, 4, false, false),
        new NumberCard(NumberType.Bamboo, 4, false, false),
        new NumberCard(NumberType.Bamboo, 5, false, false),
        new NumberCard(NumberType.Bamboo, 5, false, false),
    ];
    private static List<Card> Thirteen() => [
        new LetterCard(LetterType.White, false),
        new LetterCard(LetterType.Bloom, false),
        new LetterCard(LetterType.Bloom, false),
        new LetterCard(LetterType.Middle, false),
        new WindCard(WindDirection.East, false),
        new WindCard(WindDirection.West, false),
        new WindCard(WindDirection.South, false),
        new WindCard(WindDirection.North, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 9, false, false),
        new NumberCard(NumberType.Money, 1, false, false),
        new NumberCard(NumberType.Money, 9, false, false),
        new NumberCard(NumberType.Bamboo, 1, false, false),
        new NumberCard(NumberType.Bamboo, 9, false, false),
    ];
    private static List<Card> CleanHead() => [
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
        new NumberCard(NumberType.Wheel, 1, false, false),
    ];
}