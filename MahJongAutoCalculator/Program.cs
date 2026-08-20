using System.Diagnostics;
using System.Text;

namespace MahJongAutoCalculator;

public class Program {
	public static void Main() {
		Console.OutputEncoding = Encoding.UTF8;
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

		var hands = Test1();
		var calculator = new Calculator(true);
		var result = calculator.Calc(setting, hands.Item1, hands.Item2, [], new NumberCard(NumberType.Money, 1 ,false));
		Console.WriteLine(result);
	}

	private float BenchMaking(IOrderedEnumerable<Card> pHands, int pAmount) {
		var timer = new Stopwatch();
		timer.Start();
		while (pAmount --> 0) {
			//Separator.Separate(pHands);
		}
		timer.Stop();
		return timer.ElapsedMilliseconds; 
	}

	private static (List<Card>, List<Card>) SevenHead() => ([],[
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
		new NumberCard(NumberType.Wheel, 2, false),
	]);
	private static (List<Card>, List<Card>) Big() => ([
		new LetterCard(LetterType.White),
		new LetterCard(LetterType.White),
		new LetterCard(LetterType.White),
		new LetterCard(LetterType.Bloom),
		new LetterCard(LetterType.Bloom),
		new LetterCard(LetterType.Bloom),
	], [
		new LetterCard(LetterType.Middle),
		new LetterCard(LetterType.Middle),
		new WindCard(WindDirection.East),
		new WindCard(WindDirection.East),
		new WindCard(WindDirection.East),
		new NumberCard(NumberType.Wheel, 1, true),
		new NumberCard(NumberType.Wheel, 1, true),
		new NumberCard(NumberType.Wheel, 1, false),
	]);
	private static (List<Card>, List<Card>) Test() => ([
		new NumberCard(NumberType.Wheel, 1, false), 
		new NumberCard(NumberType.Wheel, 3, false), 
		new NumberCard(NumberType.Wheel, 2, false), 
		new NumberCard(NumberType.Wheel, 1, false), 
		new NumberCard(NumberType.Wheel, 1, false), 
		new NumberCard(NumberType.Wheel, 1, false), 		
		new NumberCard(NumberType.Wheel, 1, false), 		
		new NumberCard(NumberType.Money, 3, false), 
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 2, false), 
	], [
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 9, false), 
		new NumberCard(NumberType.Money, 9, false), 
	]);
	private static (List<Card>, List<Card>) Test1() => ([],[
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 1, false), 
		new NumberCard(NumberType.Money, 8, false), 
		new NumberCard(NumberType.Money, 7, false), 
		new NumberCard(NumberType.Money, 9, false), 		
		new NumberCard(NumberType.Wheel, 4, false), 		
		new NumberCard(NumberType.Wheel, 3, false), 
		new NumberCard(NumberType.Wheel, 5, false), 
		new NumberCard(NumberType.Bamboo, 6, false), 
		new NumberCard(NumberType.Bamboo, 8, false), 
		new NumberCard(NumberType.Bamboo, 7, false), 
		new NumberCard(NumberType.Bamboo, 9, false), 
		new NumberCard(NumberType.Bamboo, 9, false), 
	]);
	private static List<Card> Thirteen() => [
		new LetterCard(LetterType.White),
		new LetterCard(LetterType.Bloom),
		new LetterCard(LetterType.Bloom),
		new LetterCard(LetterType.Middle),
		new WindCard(WindDirection.East),
		new WindCard(WindDirection.West),
		new WindCard(WindDirection.South),
		new WindCard(WindDirection.North),
		new NumberCard(NumberType.Wheel, 1, false),
		new NumberCard(NumberType.Wheel, 9, false),
		new NumberCard(NumberType.Money, 1, false),
		new NumberCard(NumberType.Money, 9, false),
		new NumberCard(NumberType.Bamboo, 1, false),
		new NumberCard(NumberType.Bamboo, 9, false),
	];
}