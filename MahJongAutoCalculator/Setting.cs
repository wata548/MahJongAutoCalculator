namespace MahJongAutoCalculator;

public record Setting(
	bool IsParent,
	WindDirection RoundWind,
	WindDirection SeatWind,
	int NorthCnt,
	bool IsRich,
	bool IsFirstTurn,
	bool IsLastCard,
	bool IsRon,
	bool IsOneShot,
	bool IsOpenInKingTable,
	bool HaveCried
);