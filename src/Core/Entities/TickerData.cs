using CryptoTracker.Core.Enums;

namespace CryptoTracker.Core.Entities;

public record TickerData(
	decimal LastPrice,
	decimal LowPrice24H,
	decimal HighPrice24H,
	decimal ChangePercentage24H,
	string Exchange,
	TradingPair Pair);
