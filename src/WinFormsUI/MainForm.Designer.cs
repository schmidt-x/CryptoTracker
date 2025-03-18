using System.Windows.Forms;

namespace CryptoTracker.WinFormsUI;

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
		dataGridView1 = new DataGridView();
		checkBox1 = new CheckBox();
		comboBox1 = new ComboBox();
		listBox1 = new ListBox();
		label1 = new Label();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		SuspendLayout();
		// 
		// dataGridView1
		// 
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
		dataGridView1.Dock = DockStyle.Top;
		dataGridView1.Location = new System.Drawing.Point(15, 15);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.ReadOnly = true;
		dataGridView1.RowHeadersVisible = false;
		dataGridView1.RowTemplate.ReadOnly = true;
		dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
		dataGridView1.Size = new System.Drawing.Size(754, 146);
		dataGridView1.TabIndex = 0;
		// 
		// checkBox1
		// 
		checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		checkBox1.AutoSize = true;
		checkBox1.Location = new System.Drawing.Point(525, 374);
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
		comboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox1.FormattingEnabled = true;
		comboBox1.Location = new System.Drawing.Point(648, 370);
		comboBox1.Name = "comboBox1";
		comboBox1.Size = new System.Drawing.Size(121, 23);
		comboBox1.TabIndex = 2;
		// 
		// listBox1
		// 
		listBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox1.FormattingEnabled = true;
		listBox1.Location = new System.Drawing.Point(15, 204);
		listBox1.Name = "listBox1";
		listBox1.Size = new System.Drawing.Size(754, 139);
		listBox1.TabIndex = 4;
		// 
		// label1
		// 
		label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(15, 186);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(32, 15);
		label1.TabIndex = 5;
		label1.Text = "Logs";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new System.Drawing.Size(784, 411);
		Controls.Add(dataGridView1);
		Controls.Add(label1);
		Controls.Add(listBox1);
		Controls.Add(checkBox1);
		Controls.Add(comboBox1);
		Name = "MainForm";
		Padding = new Padding(15);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Crypto Tracker";
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	
	private System.Windows.Forms.DataGridView dataGridView1;
	private System.Windows.Forms.CheckBox checkBox1;
	private System.Windows.Forms.ComboBox comboBox1;
	private ListBox listBox1;
	private Label label1;
}
