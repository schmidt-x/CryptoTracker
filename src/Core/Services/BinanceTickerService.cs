using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoTracker.Core.Entities;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Extensions;

namespace CryptoTracker.Core.Services;

public class BinanceTickerService : ITickerService
{
	private readonly IBinanceRestClient _restClient;
	private readonly IBinanceSocketClient _socketClient;

	internal BinanceTickerService(IBinanceRestClient? restClient, IBinanceSocketClient? socketClient)
	{
		_restClient = restClient ?? new BinanceRestClient();
		_socketClient = socketClient ?? new BinanceSocketClient();
	}
	
	public string Exchange => _restClient.Exchange;
	
	public async Task<CallResult<TickerData>> GetTickerAsync(TradingPair pair, CancellationToken ct = default)
	{
		var result = await _restClient.SpotApi.ExchangeData.GetTickerAsync(pair.ToNormalizedString(), ct);
		
		return result.Success
			? new CallResult<TickerData>(ToTickerData(result.Data, pair))
			: result.AsError<TickerData>(result.Error!);
	}

	public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
		TradingPair pair,
		Action<TickerData> onUpdate,
		CancellationToken ct = default) 
	{
		return await _socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(
			pair.ToNormalizedString(),
			update => onUpdate(ToTickerData(update.Data, pair)),
			ct);
	}
	
	private TickerData ToTickerData(IBinanceTick tick, TradingPair pair) =>
		new(tick.LastPrice, tick.LowPrice, tick.HighPrice, tick.PriceChangePercent / 100m, Exchange, pair);
}