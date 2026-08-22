using System.Diagnostics;
using System.Text;

namespace MahJongAutoCalculator;

public class Program {
	public static void Main() {
		Console.OutputEncoding = Encoding.UTF8;
		var setting = new Setting(
			false,
			WindDirection.South,
			WindDirection.South,
			4,
			false,
			true,
			false,
			true,
			true,
			false,
			false,
			true
		);
		Console.WriteLine(Execute(setting).ToString(setting));
	}

	private static Score Execute(Setting pSetting) {
		var hands = SevenHead2();
		var calculator = new Calculator(true);
		return calculator.Calc(pSetting, 
			Card.Parse(hands.Cry),
			Card.Parse(hands.Hand), 
			Card.Parse(hands.Dora), 
			Card.Parse(hands.Last).First(), out _);
	}
	
	private static float BenchMaking(int pAmount, Setting pSetting) {
		var timer = new Stopwatch();
		timer.Start();
		while (pAmount --> 0) {
			Execute(pSetting);
		}
		timer.Stop();
		return timer.ElapsedMilliseconds; 
	}

	private record CardArgs(string Cry, string Hand, string Dora, string Last);
	private static CardArgs SevenHead() => new("","22222222222222m", "", "2m");
	private static CardArgs SevenHead1() => new("","11223399m223344p", "", "9m");
	private static CardArgs SevenHead2() => new("","1133557799m1133s", "", "3s");
	private static CardArgs Big() => new("ggg", "hhhhmmssss1111p", "9999pmmeeee", "m");
	private static CardArgs Test() => new("1111123p123m", "11199m", "", "1m");
	private static CardArgs Test1() => new("", "111879m345p6789s", "", "1m");
	private static CardArgs Thirteen() => new("", "19m19p19swesnmhgg", "", "g");
	private static CardArgs Small() => new("", "234576m234567p55s", "", "7p");
}