using CryptoTracker.Core.Enums;

namespace CryptoTracker.Core.Extensions;

internal static class HelperExtensions
{
	// Note: While Binance, Bitget and Bybit accept pairs in a combined form (e.g., BTCUSDT),
	// Kucoin requires the pair to be separated by a hyphen ('-') (e.g., BTC-USDT).
	internal static string ToNormalizedString(this TradingPair pair, char? separator = null)
		=> pair.ToString().Replace("_", separator?.ToString() ?? string.Empty);
	
}