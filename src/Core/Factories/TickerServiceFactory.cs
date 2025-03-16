using Microsoft.Extensions.DependencyInjection;
using System;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Services;

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
			ExchangeName.Binance => throw new NotImplementedException(),
			ExchangeName.Bybit   => throw new NotImplementedException(),
			ExchangeName.Kucoin  => throw new NotImplementedException(),
			ExchangeName.Bitget  => throw new NotImplementedException(),
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