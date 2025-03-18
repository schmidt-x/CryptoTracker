using System;
using System.ComponentModel;
using System.Windows.Forms;
using CryptoTracker.Core.Enums;
using CryptoTracker.Core.Factories;
using CryptoTracker.Core.Services;
using CryptoTracker.WinFormsUI.Common;
using CryptoTracker.WinFormsUI.Listeners;
using CryptoTracker.WinFormsUI.Models;

namespace CryptoTracker.WinFormsUI;

public partial class MainForm : Form
{
	private readonly SocketListener _socketListener;
	private readonly RestListener _restListener;
	private readonly TradingPair[] _pairs;
	private readonly ILogger _logger;

	private TradingPair _currentPair;

	public MainForm()
	{
		InitializeComponent();

		_pairs = [ TradingPair.BTC_USDT, TradingPair.ETH_USDT, TradingPair.TON_USDT ];

		var factory = new TickerServiceFactory();

		ITickerService[] services = [
			factory.Create(ExchangeName.Binance),
			factory.Create(ExchangeName.Bitget),
			factory.Create(ExchangeName.Bybit),
			factory.Create(ExchangeName.Kucoin)
		];

		var models = InitDataGridView1(services);
		_currentPair = InitComboBox1(_pairs);

		_logger = new DummyLogger(listBox1);
		
		const int interval = 5000;
		_restListener = new RestListener(interval, services, models, _logger);
		_socketListener = new SocketListener(services, models, _logger);

		_ = _restListener.StartAsync(_currentPair);
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		// TODO:
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		// TODO:
	}

	private TradingPair InitComboBox1(TradingPair[] pairs)
	{
		const int selectedIndex = 0;
		comboBox1.Items.AddRange([.. pairs]);
		comboBox1.SelectedIndex = selectedIndex;
		comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged!;
		return pairs[selectedIndex];
	}

	private BindingList<TickerModel> InitDataGridView1(ITickerService[] services)
	{
		dataGridView1.RowHeadersVisible = false;
		var list = new BindingList<TickerModel>();

		foreach (var service in services)
		{
			list.Add(new TickerModel { Exchange = service.Exchange });
		}

		dataGridView1.DataSource = list;
		return list;
	}
}