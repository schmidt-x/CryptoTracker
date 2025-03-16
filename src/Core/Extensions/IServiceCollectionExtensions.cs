using CryptoTracker.Core.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTracker.Core.Extensions;

// Resharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddTickerServiceFactory(this IServiceCollection services)
	{
		return services
			.AddBinance()
			.AddBitget()
			.AddBybit()
			.AddKucoin()
			.AddSingleton<ITickerServiceFactory>(sp => new TickerServiceFactory(sp));
	}
}
