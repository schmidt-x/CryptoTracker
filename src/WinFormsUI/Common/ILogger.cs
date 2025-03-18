using System;
using System.Windows.Forms;

namespace CryptoTracker.WinFormsUI.Common;

public interface ILogger
{
	void LogMessage(string message);
}

public class DummyLogger : ILogger
{
	private readonly ListBox _listBox;

	public DummyLogger(ListBox listBox)
	{
		_listBox = listBox;
	}
	
	public void LogMessage(string message)
	{
		if (_listBox.InvokeRequired)
		{
			_listBox.Invoke(Log, message);
		}
		else
		{
			Log(message);
		}
	}
	
	private void Log(string message)
	{
		var msg = $"{DateTimeOffset.UtcNow:O} {message}";
		
		_listBox.Items.Add(msg);
		_listBox.SelectedIndex = _listBox.Items.Count - 1;
	}
}
