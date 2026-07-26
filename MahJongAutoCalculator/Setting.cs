namespace MahJongAutoCalculator;

public record Setting(
	bool IsParent,
	WindDirection LongWind,
	WindDirection PlayerWind,
	bool IsRich,
	bool IsFirstTurn,
	bool IsLastCard,
	bool IsRon,
	bool IsOneShot,
	bool IsOpenInKingTable,
	bool HaveCried
);