using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoTracker.Core.Entities;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Extensions;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Models.Spot;
using Kucoin.Net.Objects.Models.Spot.Socket;

namespace CryptoTracker.Core.Services;

public class KucoinTickerService : ITickerService
{
	private readonly IKucoinRestClient _restClient;
	private readonly IKucoinSocketClient _socketClient;
	
	public KucoinTickerService(IKucoinRestClient? restClient, IKucoinSocketClient? socketClient)
	{
		_restClient = restClient ?? new KucoinRestClient();
		_socketClient = socketClient ?? new KucoinSocketClient();
	}
	
	public string Exchange => "Kucoin";
	
	public async Task<CallResult<TickerData>> GetTickerAsync(TradingPair pair, CancellationToken ct = default)
	{
		var result = await _restClient.SpotApi.ExchangeData.Get24HourStatsAsync(pair.ToNormalizedString('-'), ct);
		
		return result.Success
			? new CallResult<TickerData>(ToTickerData(result.Data))
			: result.AsError<TickerData>(result.Error!);
	}

	public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
		TradingPair pair,
		Action<TickerData> onUpdate,
		CancellationToken ct = default)
	{
		// Unfortunately, unlike the REST client, the Web-sockets API does not provide 24-hour metrics.
		// Therefore, only the 'LastPrice' is returned :(
		// https://www.kucoin.com/docs/websocket/spot-trading/public-channels/ticker
		return await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(
			pair.ToNormalizedString('-'),
			update => onUpdate(ToTickerData(update.Data)),
			ct);
	}
	
	private static TickerData ToTickerData(Kucoin24HourStat tick) => 
		new(tick.LastPrice ?? -1, tick.LowPrice ?? -1, tick.HighPrice ?? -1, tick.ChangePercentage ?? 0);
	
	private static TickerData ToTickerData(KucoinStreamTick tick) => new(tick.LastPrice ?? -1, -1, -1, 0);
}