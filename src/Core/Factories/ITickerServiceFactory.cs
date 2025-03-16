using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Services;

namespace CryptoTracker.Core.Factories;

public interface ITickerServiceFactory
{
	ITickerService Create(ExchangeName exchange);
}