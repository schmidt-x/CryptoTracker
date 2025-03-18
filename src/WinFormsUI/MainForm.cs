using System;
using System.Windows.Forms;

namespace CryptoTracker.WinFormsUI;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
		
		// InitComboBox1();
		comboBox1.SelectedIndex = 0;
		
		// InitDataGridView1();
		dataGridView1.RowHeadersVisible = false;
		
		
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		// TODO:
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		// TODO:
	}
}
