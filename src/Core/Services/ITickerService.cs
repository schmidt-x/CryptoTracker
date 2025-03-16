using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoTracker.Core.Entities;
using CryptoTracker.Core.Enums;

namespace CryptoTracker.Core.Services;

public interface ITickerService
{
	/// <summary>
	/// The name of the exchange being used.
	/// </summary>
	string Exchange { get; }
	
	Task<CallResult<TickerData>> GetTickerAsync(TradingPair pair, CancellationToken ct = default);
	
	Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
		TradingPair pair, Action<TickerData> onUpdate, CancellationToken ct = default);
}