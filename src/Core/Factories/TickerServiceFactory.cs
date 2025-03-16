using Microsoft.Extensions.DependencyInjection;
using System;
using Binance.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Services;
using Kucoin.Net.Interfaces.Clients;

namespace CryptoTracker.Core.Factories;

public class TickerServiceFactory : ITickerServiceFactory
{
	private readonly IServiceProvider? _sp;

	public TickerServiceFactory() { }
	
	internal TickerServiceFactory(IServiceProvider sp)
	{
		_sp = sp;
	}
	
	public ITickerService Create(ExchangeName exchange)
	{
		return exchange switch
		{
			ExchangeName.Binance => Get<IBinanceRestClient, IBinanceSocketClient>((r, s) => new BinanceTickerService(r, s)),
			ExchangeName.Bitget  => Get<IBitgetRestClient, IBitgetSocketClient>((r, s) => new BitgetTickerService(r, s)),
			ExchangeName.Bybit   => Get<IBybitRestClient, IBybitSocketClient>((r, s) => new BybitTickerService(r, s)),
			ExchangeName.Kucoin  => Get<IKucoinRestClient, IKucoinSocketClient>((r, s) => new KucoinTickerService(r, s)),
			_ => throw new ArgumentOutOfRangeException(nameof(exchange), exchange, "Invalid exchange name.")
		};
		
		ITickerService Get<TRest, TSocket>(Func<TRest?, TSocket?, ITickerService> creator)
			where TRest : notnull
			where TSocket : notnull
		{
			if (_sp is null)
			{
				return creator.Invoke(default, default);
			}
			
			var restClient = _sp.GetRequiredService<TRest>();
			var socketClient = _sp.GetRequiredService<TSocket>();
			
			return creator.Invoke(restClient, socketClient);
		}
	}
}