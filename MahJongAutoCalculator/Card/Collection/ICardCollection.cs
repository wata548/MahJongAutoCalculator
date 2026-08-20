namespace MahJongAutoCalculator;

public interface ICardCollection {
	WaitType GetWaitType(Card pLast);
	int GetFu(Setting pSetting);
	bool IsOpen { get; set; }
}