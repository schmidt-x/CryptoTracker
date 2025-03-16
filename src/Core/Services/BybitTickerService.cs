using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoTracker.Core.Entities;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Extensions;

namespace CryptoTracker.Core.Services;

public class BybitTickerService : ITickerService
{
	private readonly IBybitRestClient _restClient;
	private readonly IBybitSocketClient _socketClient;
	
	internal BybitTickerService(IBybitRestClient? restClient, IBybitSocketClient? socketClient)
	{
		_restClient = restClient ?? new BybitRestClient();
		_socketClient = socketClient ?? new BybitSocketClient();
	}
	
	public string Exchange => "Bybit";
	
	public async Task<CallResult<TickerData>> GetTickerAsync(TradingPair pair, CancellationToken ct = default)
	{
		var result = await _restClient.V5Api.ExchangeData.GetSpotTickersAsync(pair.ToNormalizedString(), ct);
		
		return result.Success
			? new CallResult<TickerData>(ToTickerData(result.Data.List.First()))
			: result.AsError<TickerData>(result.Error!);
	}

	public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
		TradingPair pair,
		Action<TickerData> onUpdate,
		CancellationToken ct = default)
	{
		return await _socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(
			pair.ToNormalizedString(),
			update => onUpdate(ToTickerData(update.Data)),
			ct);
	}
	
	private static TickerData ToTickerData(BybitSpotTicker tick) =>
		new(tick.LastPrice, tick.LowPrice24h, tick.HighPrice24h, tick.PriceChangePercentag24h);
	
	private static TickerData ToTickerData(BybitSpotTickerUpdate tick) =>
		new(tick.LastPrice, tick.LowPrice24h, tick.HighPrice24h, tick.PricePercentage24h);
}