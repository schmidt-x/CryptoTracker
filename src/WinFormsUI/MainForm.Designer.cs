using System.Windows.Forms;

namespace WinFormsUI;

partial class MainForm
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		dataGridView1 = new System.Windows.Forms.DataGridView();
		ExchangeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
		Diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
		Low24h = new System.Windows.Forms.DataGridViewTextBoxColumn();
		High24h = new System.Windows.Forms.DataGridViewTextBoxColumn();
		Change24h = new System.Windows.Forms.DataGridViewTextBoxColumn();
		checkBox1 = new System.Windows.Forms.CheckBox();
		comboBox1 = new System.Windows.Forms.ComboBox();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		SuspendLayout();
		// 
		// dataGridView1
		// 
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
		dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ExchangeName, Price, Diff, Low24h, High24h, Change24h });
		dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
		dataGridView1.Location = new System.Drawing.Point(15, 15);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.ReadOnly = true;
		dataGridView1.RowHeadersVisible = false;
		dataGridView1.RowTemplate.ReadOnly = true;
		dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		dataGridView1.Size = new System.Drawing.Size(754, 146);
		dataGridView1.TabIndex = 0;
		// 
		// ExchangeName
		// 
		ExchangeName.HeaderText = "Name";
		ExchangeName.Name = "ExchangeName";
		ExchangeName.ReadOnly = true;
		// 
		// Price
		// 
		Price.HeaderText = "Price";
		Price.Name = "Price";
		Price.ReadOnly = true;
		// 
		// Diff
		// 
		Diff.HeaderText = "Diff";
		Diff.Name = "Diff";
		Diff.ReadOnly = true;
		// 
		// Low24h
		// 
		Low24h.HeaderText = "Low (24h)";
		Low24h.Name = "Low24h";
		Low24h.ReadOnly = true;
		// 
		// High24h
		// 
		High24h.HeaderText = "High (24h)";
		High24h.Name = "High24h";
		High24h.ReadOnly = true;
		// 
		// Change24h
		// 
		Change24h.HeaderText = "Change (24h)";
		Change24h.Name = "Change24h";
		Change24h.ReadOnly = true;
		// 
		// checkBox1
		// 
		checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
		checkBox1.AutoSize = true;
		checkBox1.Location = new System.Drawing.Point(525, 381);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(117, 19);
		checkBox1.TabIndex = 1;
		checkBox1.Text = "Use Web-Sockets";
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.CheckedChanged += checkBox1_CheckedChanged;
		// 
		// comboBox1
		// 
		comboBox1.AllowDrop = true;
		comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
		comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		comboBox1.FormattingEnabled = true;
		comboBox1.Items.AddRange(new object[] { "BTC-USDT", "ETH-USDT", "TON-USDT" });
		comboBox1.Location = new System.Drawing.Point(648, 377);
		comboBox1.Name = "comboBox1";
		comboBox1.Size = new System.Drawing.Size(121, 23);
		comboBox1.TabIndex = 2;
		comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
		// 
		// MainForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		ClientSize = new System.Drawing.Size(784, 411);
		Controls.Add(checkBox1);
		Controls.Add(comboBox1);
		Controls.Add(dataGridView1);
		Padding = new System.Windows.Forms.Padding(15);
		StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Crypto Tracker";
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	
	private System.Windows.Forms.DataGridView dataGridView1;
	private System.Windows.Forms.CheckBox checkBox1;
	private System.Windows.Forms.ComboBox comboBox1;
	private DataGridViewTextBoxColumn ExchangeName;
	private DataGridViewTextBoxColumn Price;
	private DataGridViewTextBoxColumn Diff;
	private DataGridViewTextBoxColumn Low24h;
	private DataGridViewTextBoxColumn High24h;
	private DataGridViewTextBoxColumn Change24h;
}
