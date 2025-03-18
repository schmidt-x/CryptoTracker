using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoTracker.Core.Entities;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Extensions;

namespace CryptoTracker.Core.Services;

public class BitgetTickerService : ITickerService
{
	private readonly IBitgetRestClient _restClient;
	private readonly IBitgetSocketClient _socketClient;
	
	internal BitgetTickerService(IBitgetRestClient? restClient, IBitgetSocketClient? socketClient)
	{
		_restClient = restClient ?? new BitgetRestClient();
		_socketClient = socketClient ?? new BitgetSocketClient();
	}
	
	public string Exchange => _restClient.Exchange;
	
	public async Task<CallResult<TickerData>> GetTickerAsync(TradingPair pair, CancellationToken ct = default)
	{
		var result = await _restClient.SpotApiV2.ExchangeData.GetTickersAsync(pair.ToNormalizedString(), ct);
		
		return result.Success
			? new CallResult<TickerData>(ToTickerData(result.Data.First()))
			: result.AsError<TickerData>(result.Error!);
		
		TickerData ToTickerData(BitgetTicker ticker) =>
			new(ticker.LastPrice, ticker.LowPrice, ticker.HighPrice, ticker.ChangePercentage24H ?? 0, Exchange, pair);
	}

	public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
		TradingPair pair,
		Action<TickerData> onUpdate,
		CancellationToken ct = default)
	{
		return await _socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync(
			pair.ToNormalizedString(),
			update => onUpdate(ToTickerData(update.Data)),
			ct);
		
		TickerData ToTickerData(BitgetTickerUpdate ticker) =>
			new(ticker.LastPrice, ticker.LowPrice24h, ticker.HighPrice24h, ticker.ChangePercentage, Exchange, pair);
	}
}