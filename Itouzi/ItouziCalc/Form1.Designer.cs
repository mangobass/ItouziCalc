﻿namespace ItouziCalc
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
			this.labelPrincipal = new System.Windows.Forms.Label();
			this.labelPoundage = new System.Windows.Forms.Label();
			this.labelValueDay = new System.Windows.Forms.Label();
			this.labelTransferDay = new System.Windows.Forms.Label();
			this.labelDueDay = new System.Windows.Forms.Label();
			this.labelInterestRate = new System.Windows.Forms.Label();
			this.labelInterest = new System.Windows.Forms.Label();
			this.labelRemainInterest = new System.Windows.Forms.Label();
			this.labelDiscountGold = new System.Windows.Forms.Label();
			this.labelCreditorBenefitRate = new System.Windows.Forms.Label();
			this.labelInvestorBenefitRate = new System.Windows.Forms.Label();
			this.dateTimePickerValueDay = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDueDay = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerTransferDay = new System.Windows.Forms.DateTimePicker();
			this.textBoxPrincipal = new System.Windows.Forms.TextBox();
			this.textBoxPoundageRate = new System.Windows.Forms.TextBox();
			this.textBoxInterestRate = new System.Windows.Forms.TextBox();
			this.textBoxInterest = new System.Windows.Forms.TextBox();
			this.textBoxRemainInterest = new System.Windows.Forms.TextBox();
			this.textBoxDiscountGold = new System.Windows.Forms.TextBox();
			this.textBoxCreditorBenefitRate = new System.Windows.Forms.TextBox();
			this.textBoxInvestorBenefitRate = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxTotalInterest = new System.Windows.Forms.TextBox();
			this.labelTotalInterest = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxGainInterestDayPerMonth = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelPrincipal
			// 
			this.labelPrincipal.Location = new System.Drawing.Point(1, 13);
			this.labelPrincipal.Name = "labelPrincipal";
			this.labelPrincipal.Size = new System.Drawing.Size(87, 28);
			this.labelPrincipal.TabIndex = 0;
			this.labelPrincipal.Text = "本金";
			this.labelPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPoundage
			// 
			this.labelPoundage.Location = new System.Drawing.Point(225, 11);
			this.labelPoundage.Name = "labelPoundage";
			this.labelPoundage.Size = new System.Drawing.Size(87, 28);
			this.labelPoundage.TabIndex = 0;
			this.labelPoundage.Text = "手续费率";
			this.labelPoundage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValueDay
			// 
			this.labelValueDay.Location = new System.Drawing.Point(1, 44);
			this.labelValueDay.Name = "labelValueDay";
			this.labelValueDay.Size = new System.Drawing.Size(87, 28);
			this.labelValueDay.TabIndex = 0;
			this.labelValueDay.Text = "起息日";
			this.labelValueDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTransferDay
			// 
			this.labelTransferDay.Location = new System.Drawing.Point(225, 45);
			this.labelTransferDay.Name = "labelTransferDay";
			this.labelTransferDay.Size = new System.Drawing.Size(87, 28);
			this.labelTransferDay.TabIndex = 0;
			this.labelTransferDay.Text = "到期日";
			this.labelTransferDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDueDay
			// 
			this.labelDueDay.Location = new System.Drawing.Point(1, 80);
			this.labelDueDay.Name = "labelDueDay";
			this.labelDueDay.Size = new System.Drawing.Size(87, 28);
			this.labelDueDay.TabIndex = 0;
			this.labelDueDay.Text = "转让日";
			this.labelDueDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelInterestRate
			// 
			this.labelInterestRate.Location = new System.Drawing.Point(225, 79);
			this.labelInterestRate.Name = "labelInterestRate";
			this.labelInterestRate.Size = new System.Drawing.Size(87, 28);
			this.labelInterestRate.TabIndex = 0;
			this.labelInterestRate.Text = "原年化利率";
			this.labelInterestRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelInterest
			// 
			this.labelInterest.Location = new System.Drawing.Point(3, 39);
			this.labelInterest.Name = "labelInterest";
			this.labelInterest.Size = new System.Drawing.Size(87, 28);
			this.labelInterest.TabIndex = 0;
			this.labelInterest.Text = "已收利息";
			this.labelInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRemainInterest
			// 
			this.labelRemainInterest.Location = new System.Drawing.Point(227, 39);
			this.labelRemainInterest.Name = "labelRemainInterest";
			this.labelRemainInterest.Size = new System.Drawing.Size(87, 28);
			this.labelRemainInterest.TabIndex = 0;
			this.labelRemainInterest.Text = "未收利息";
			this.labelRemainInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDiscountGold
			// 
			this.labelDiscountGold.Location = new System.Drawing.Point(13, 25);
			this.labelDiscountGold.Name = "labelDiscountGold";
			this.labelDiscountGold.Size = new System.Drawing.Size(81, 28);
			this.labelDiscountGold.TabIndex = 0;
			this.labelDiscountGold.Text = "折让金";
			this.labelDiscountGold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelCreditorBenefitRate
			// 
			this.labelCreditorBenefitRate.Location = new System.Drawing.Point(13, 79);
			this.labelCreditorBenefitRate.Name = "labelCreditorBenefitRate";
			this.labelCreditorBenefitRate.Size = new System.Drawing.Size(81, 28);
			this.labelCreditorBenefitRate.TabIndex = 0;
			this.labelCreditorBenefitRate.Text = "原债权人收益";
			this.labelCreditorBenefitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelInvestorBenefitRate
			// 
			this.labelInvestorBenefitRate.Location = new System.Drawing.Point(11, 135);
			this.labelInvestorBenefitRate.Name = "labelInvestorBenefitRate";
			this.labelInvestorBenefitRate.Size = new System.Drawing.Size(83, 28);
			this.labelInvestorBenefitRate.TabIndex = 0;
			this.labelInvestorBenefitRate.Text = "投资人收益";
			this.labelInvestorBenefitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePickerValueDay
			// 
			this.dateTimePickerValueDay.Location = new System.Drawing.Point(110, 50);
			this.dateTimePickerValueDay.Name = "dateTimePickerValueDay";
			this.dateTimePickerValueDay.Size = new System.Drawing.Size(109, 21);
			this.dateTimePickerValueDay.TabIndex = 1;
			this.dateTimePickerValueDay.Leave += new System.EventHandler(this.dateTimePickerValueDay_Leave);
			// 
			// dateTimePickerDueDay
			// 
			this.dateTimePickerDueDay.Location = new System.Drawing.Point(318, 50);
			this.dateTimePickerDueDay.Name = "dateTimePickerDueDay";
			this.dateTimePickerDueDay.Size = new System.Drawing.Size(109, 21);
			this.dateTimePickerDueDay.TabIndex = 1;
			this.dateTimePickerDueDay.Leave += new System.EventHandler(this.dateTimePickerDueDay_Leave);
			// 
			// dateTimePickerTransferDay
			// 
			this.dateTimePickerTransferDay.Location = new System.Drawing.Point(110, 86);
			this.dateTimePickerTransferDay.Name = "dateTimePickerTransferDay";
			this.dateTimePickerTransferDay.Size = new System.Drawing.Size(109, 21);
			this.dateTimePickerTransferDay.TabIndex = 1;
			this.dateTimePickerTransferDay.Leave += new System.EventHandler(this.dateTimePickerTransferDay_Leave);
			// 
			// textBoxPrincipal
			// 
			this.textBoxPrincipal.Location = new System.Drawing.Point(109, 17);
			this.textBoxPrincipal.Name = "textBoxPrincipal";
			this.textBoxPrincipal.Size = new System.Drawing.Size(109, 21);
			this.textBoxPrincipal.TabIndex = 0;
			this.textBoxPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxPrincipal.Leave += new System.EventHandler(this.textBoxPrincipal_Leave);
			this.textBoxPrincipal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPrincipal_KeyUp);
			this.textBoxPrincipal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrincipal_KeyPress);
			// 
			// textBoxPoundageRate
			// 
			this.textBoxPoundageRate.Location = new System.Drawing.Point(318, 17);
			this.textBoxPoundageRate.Name = "textBoxPoundageRate";
			this.textBoxPoundageRate.Size = new System.Drawing.Size(87, 21);
			this.textBoxPoundageRate.TabIndex = 2;
			this.textBoxPoundageRate.Text = "0.5";
			this.textBoxPoundageRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxPoundageRate.Leave += new System.EventHandler(this.textBoxPoundageRate_Leave);
			this.textBoxPoundageRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPoundageRate_KeyPress);
			// 
			// textBoxInterestRate
			// 
			this.textBoxInterestRate.Location = new System.Drawing.Point(318, 85);
			this.textBoxInterestRate.Name = "textBoxInterestRate";
			this.textBoxInterestRate.Size = new System.Drawing.Size(87, 21);
			this.textBoxInterestRate.TabIndex = 2;
			this.textBoxInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxInterestRate.Leave += new System.EventHandler(this.textBoxInterestRate_Leave);
			this.textBoxInterestRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInterestRate_KeyUp);
			this.textBoxInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInterestRate_KeyPress);
			// 
			// textBoxInterest
			// 
			this.textBoxInterest.Location = new System.Drawing.Point(111, 43);
			this.textBoxInterest.Name = "textBoxInterest";
			this.textBoxInterest.Size = new System.Drawing.Size(109, 21);
			this.textBoxInterest.TabIndex = 2;
			this.textBoxInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxInterest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInterest_KeyUp);
			this.textBoxInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInterest_KeyPress);
			// 
			// textBoxRemainInterest
			// 
			this.textBoxRemainInterest.Location = new System.Drawing.Point(320, 43);
			this.textBoxRemainInterest.Name = "textBoxRemainInterest";
			this.textBoxRemainInterest.Size = new System.Drawing.Size(109, 21);
			this.textBoxRemainInterest.TabIndex = 2;
			this.textBoxRemainInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxRemainInterest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxRemainInterest_KeyUp);
			this.textBoxRemainInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRemainInterest_KeyPress);
			// 
			// textBoxDiscountGold
			// 
			this.textBoxDiscountGold.Location = new System.Drawing.Point(115, 30);
			this.textBoxDiscountGold.Name = "textBoxDiscountGold";
			this.textBoxDiscountGold.Size = new System.Drawing.Size(109, 21);
			this.textBoxDiscountGold.TabIndex = 2;
			this.textBoxDiscountGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxDiscountGold.Leave += new System.EventHandler(this.textBoxDiscountGold_Leave);
			this.textBoxDiscountGold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxDiscountGold_KeyUp);
			// 
			// textBoxCreditorBenefitRate
			// 
			this.textBoxCreditorBenefitRate.Location = new System.Drawing.Point(115, 84);
			this.textBoxCreditorBenefitRate.Name = "textBoxCreditorBenefitRate";
			this.textBoxCreditorBenefitRate.Size = new System.Drawing.Size(90, 21);
			this.textBoxCreditorBenefitRate.TabIndex = 2;
			this.textBoxCreditorBenefitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxCreditorBenefitRate.Leave += new System.EventHandler(this.textBoxCreditorBenefitRate_Leave);
			this.textBoxCreditorBenefitRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxCreditorBenefitRate_KeyUp);
			// 
			// textBoxInvestorBenefitRate
			// 
			this.textBoxInvestorBenefitRate.Location = new System.Drawing.Point(115, 140);
			this.textBoxInvestorBenefitRate.Name = "textBoxInvestorBenefitRate";
			this.textBoxInvestorBenefitRate.Size = new System.Drawing.Size(90, 21);
			this.textBoxInvestorBenefitRate.TabIndex = 2;
			this.textBoxInvestorBenefitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxInvestorBenefitRate.Leave += new System.EventHandler(this.textBoxInvestorBenefitRate_Leave);
			this.textBoxInvestorBenefitRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInvestorBenefitRate_KeyUp);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxInvestorBenefitRate);
			this.groupBox1.Controls.Add(this.textBoxCreditorBenefitRate);
			this.groupBox1.Controls.Add(this.textBoxDiscountGold);
			this.groupBox1.Controls.Add(this.labelInvestorBenefitRate);
			this.groupBox1.Controls.Add(this.labelCreditorBenefitRate);
			this.groupBox1.Controls.Add(this.labelDiscountGold);
			this.groupBox1.Location = new System.Drawing.Point(23, 236);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(443, 190);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(206, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(11, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "%";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(207, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(11, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "%";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxRemainInterest);
			this.groupBox2.Controls.Add(this.textBoxTotalInterest);
			this.groupBox2.Controls.Add(this.textBoxInterest);
			this.groupBox2.Controls.Add(this.labelRemainInterest);
			this.groupBox2.Controls.Add(this.labelTotalInterest);
			this.groupBox2.Controls.Add(this.labelInterest);
			this.groupBox2.Location = new System.Drawing.Point(23, 165);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(442, 71);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			// 
			// textBoxTotalInterest
			// 
			this.textBoxTotalInterest.Location = new System.Drawing.Point(111, 20);
			this.textBoxTotalInterest.Name = "textBoxTotalInterest";
			this.textBoxTotalInterest.Size = new System.Drawing.Size(109, 21);
			this.textBoxTotalInterest.TabIndex = 2;
			this.textBoxTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxTotalInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTotalInterest_KeyPress);
			// 
			// labelTotalInterest
			// 
			this.labelTotalInterest.Location = new System.Drawing.Point(3, 11);
			this.labelTotalInterest.Name = "labelTotalInterest";
			this.labelTotalInterest.Size = new System.Drawing.Size(87, 28);
			this.labelTotalInterest.TabIndex = 0;
			this.labelTotalInterest.Text = "总利息";
			this.labelTotalInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxGainInterestDayPerMonth);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.textBoxInterestRate);
			this.groupBox3.Controls.Add(this.textBoxPoundageRate);
			this.groupBox3.Controls.Add(this.textBoxPrincipal);
			this.groupBox3.Controls.Add(this.dateTimePickerTransferDay);
			this.groupBox3.Controls.Add(this.dateTimePickerDueDay);
			this.groupBox3.Controls.Add(this.dateTimePickerValueDay);
			this.groupBox3.Controls.Add(this.labelPoundage);
			this.groupBox3.Controls.Add(this.labelInterestRate);
			this.groupBox3.Controls.Add(this.labelTransferDay);
			this.groupBox3.Controls.Add(this.labelValueDay);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.labelDueDay);
			this.groupBox3.Controls.Add(this.labelPrincipal);
			this.groupBox3.Location = new System.Drawing.Point(25, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(440, 149);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			// 
			// textBoxGainInterestDayPerMonth
			// 
			this.textBoxGainInterestDayPerMonth.Location = new System.Drawing.Point(109, 122);
			this.textBoxGainInterestDayPerMonth.Name = "textBoxGainInterestDayPerMonth";
			this.textBoxGainInterestDayPerMonth.Size = new System.Drawing.Size(110, 21);
			this.textBoxGainInterestDayPerMonth.TabIndex = 4;
			this.textBoxGainInterestDayPerMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxGainInterestDayPerMonth.Leave += new System.EventHandler(this.textBoxGainInterestDayPerMonth_Leave);
			this.textBoxGainInterestDayPerMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxGainInterestDayPerMonth_KeyUp);
			this.textBoxGainInterestDayPerMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGainInterestDayPerMonth_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(408, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(11, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "%";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(408, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(11, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "%";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(1, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 28);
			this.label5.TabIndex = 0;
			this.label5.Text = "月还息日";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 525);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "爱投资债权转让计算器v0.91";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelPrincipal;
		private System.Windows.Forms.Label labelPoundage;
		private System.Windows.Forms.Label labelValueDay;
		private System.Windows.Forms.Label labelTransferDay;
		private System.Windows.Forms.Label labelDueDay;
		private System.Windows.Forms.Label labelInterestRate;
		private System.Windows.Forms.Label labelInterest;
		private System.Windows.Forms.Label labelRemainInterest;
		private System.Windows.Forms.Label labelDiscountGold;
		private System.Windows.Forms.Label labelCreditorBenefitRate;
		private System.Windows.Forms.Label labelInvestorBenefitRate;
		private System.Windows.Forms.DateTimePicker dateTimePickerValueDay;
		private System.Windows.Forms.DateTimePicker dateTimePickerDueDay;
		private System.Windows.Forms.DateTimePicker dateTimePickerTransferDay;
		private System.Windows.Forms.TextBox textBoxPrincipal;
		private System.Windows.Forms.TextBox textBoxPoundageRate;
		private System.Windows.Forms.TextBox textBoxInterestRate;
		private System.Windows.Forms.TextBox textBoxInterest;
		private System.Windows.Forms.TextBox textBoxRemainInterest;
		private System.Windows.Forms.TextBox textBoxDiscountGold;
		private System.Windows.Forms.TextBox textBoxCreditorBenefitRate;
		private System.Windows.Forms.TextBox textBoxInvestorBenefitRate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelTotalInterest;
		private System.Windows.Forms.TextBox textBoxTotalInterest;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxGainInterestDayPerMonth;
	}
}

