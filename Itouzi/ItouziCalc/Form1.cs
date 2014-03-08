using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItouziCalc
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private float GetDailyInterestRate()
		{
			float dailyInterestRate = 0.0F;
			if (float.TryParse(textBox3.Text, out dailyInterestRate))
			{
				dailyInterestRate /= 365;
			}

			return dailyInterestRate / 100;
		}

		private float GetDailyInterestRate(bool leapYear)
		{
			float dailyInterestRate = 0.0F;
			if (float.TryParse(textBox3.Text, out dailyInterestRate)) {
				dailyInterestRate /= (leapYear ? 366 : 365);
			}

			return dailyInterestRate/100;
		}

		// 判断输入的字符是否是数字或点（点只能出现一次），是的话返回true，不然返回false
		private bool checkTextBoxNumberInput(TextBox obj, char c)
		{
			if ((c < 48 || c > 57) && c != 46) {
				return false;
			}

			// 已经输入过"."或者没有输入过任何数字的话，也返回false
			if (c == 46 && (obj.Text.Length == 0 || obj.Text.Contains('.'))) {
				return false;
			}

			return true;
		}

		// 计算手续费
		private double calcPoundage()
		{
			double principle = 0.0;
			float poundageRate = 0.0F;

			if (double.TryParse(textBox1.Text, out principle) && float.TryParse(textBox2.Text, out poundageRate))
			{
				return principle * poundageRate;
			}
			return 0.0;
		}

		// value date   due date    transfer date
		private int getValueDateToDueDate()
		{
			DateTime tmValueDate = dateTimePicker1.Value;
			String valueDate = tmValueDate.Month.ToString()+"/"+tmValueDate.Day.ToString()+"/"+tmValueDate.Year.ToString()+" 00:00:00";
			DateTime newTmValueDate = DateTime.Parse(valueDate);

			DateTime tmDueDate = dateTimePicker2.Value;
			String dueDate = tmDueDate.Month.ToString() + "/" + tmDueDate.Day.ToString() + "/" + tmDueDate.Year.ToString() + " 00:00:00";
			DateTime newTmDueDate = DateTime.Parse(dueDate);

			TimeSpan tmSpan = newTmDueDate.Subtract(newTmValueDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private int getValueDateToTransferDate()
		{
			DateTime tmValueDate = dateTimePicker1.Value;
			String valueDate = tmValueDate.Month.ToString() + "/" + tmValueDate.Day.ToString() + "/" + tmValueDate.Year.ToString() + " 00:00:00";
			DateTime newTmValueDate = DateTime.Parse(valueDate);

			DateTime tmTransferDate = dateTimePicker3.Value;
			String transferDate = tmTransferDate.Month.ToString() + "/" + tmTransferDate.Day.ToString() + "/" + tmTransferDate.Year.ToString() + " 00:00:00";
			DateTime newTmTransferDate = DateTime.Parse(transferDate);

			TimeSpan tmSpan = newTmTransferDate.Subtract(newTmValueDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private int GetTransferDateToDueDate()
		{
			DateTime tmTransferDate = dateTimePicker3.Value;
			String transferDate = tmTransferDate.Month.ToString() + "/" + tmTransferDate.Day.ToString() + "/" + tmTransferDate.Year.ToString() + " 00:00:00";
			DateTime newTmTransferDate = DateTime.Parse(transferDate);

			DateTime tmDueDate = dateTimePicker2.Value;
			String dueDate = tmDueDate.Month.ToString() + "/" + tmDueDate.Day.ToString() + "/" + tmDueDate.Year.ToString() + " 00:00:00";
			DateTime newTmDueDate = DateTime.Parse(dueDate);

			TimeSpan tmSpan = newTmDueDate.Subtract(newTmTransferDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private double getInterest(DateTime tm, double days)
		{
			DateTime time = tm;
			float dailyInterestRate = GetDailyInterestRate(DateTime.IsLeapYear(time.Year));
			int monthBegin = tm.Month;
			int totalDays = int.Parse(days.ToString());
			int monthNum = 0;
			double interest = 0;
			while (true)
			{
				double interestTmp = 0;
				switch (monthBegin)
				{
					case 1:
					case 3:
					case 5:
					case 7:
					case 8:
					case 10:
					case 12:
						totalDays -= 31;
						interestTmp += 31 * dailyInterestRate;
						break;
					case 4:
					case 6:
					case 9:
					case 11:
						totalDays -= 30;
						interestTmp += 30 * dailyInterestRate;
						break;
					case 2:
						{
							if (DateTime.IsLeapYear(time.Year)) {
								totalDays -= 29;
								interestTmp += 29 * dailyInterestRate;
							} else {
								totalDays -= 28;
								interestTmp += 28 * dailyInterestRate;
							}
						}
						break;
				}
				if (totalDays >= 0) {
					interest += interestTmp*double.Parse(textBox1.Text);
					++monthNum;
					monthBegin = (monthBegin + 1) % 12;
					if (monthBegin == 0) {
						monthBegin = 12;
					} else if (monthBegin == 1) {
						time = time.AddYears(1);
						dailyInterestRate = GetDailyInterestRate(DateTime.IsLeapYear(time.Year));
					}
				} else {
					break;
				}
			}
			return interest;
		}

		private void dateTimePicker1_Leave(object sender, EventArgs e)
		{
			DateTime tm = dateTimePicker1.Value;
			calcInterest();
		}

		private void dateTimePicker2_Leave(object sender, EventArgs e)
		{
			DateTime tm = dateTimePicker2.Value;
			calcInterest();
		}

		private void dateTimePicker3_Leave(object sender, EventArgs e)
		{
			DateTime tm = dateTimePicker3.Value;
			calcInterest();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBox1, e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBox2, e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBox3, e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBox4, e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBox5, e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox4.Text == "" ||
				textBox5.Text == "") {
				return;
			}

			if (textBox6.Text != "") {
				return;
			}

			if (textBox7.Text != "") {
				double principal = double.Parse(textBox1.Text);
				double investmentTotalDateNum = getValueDateToDueDate();
				double investmentDateNum = getValueDateToTransferDate();
				double interest = double.Parse(textBox4.Text);
				double creditorBenefit = double.Parse(textBox7.Text);
				double discountGold = 0;
				discountGold = -((creditorBenefit * investmentDateNum / investmentTotalDateNum) * principal - interest + calcPoundage());
				textBox6.Text = discountGold.ToString("0.00");

				return;
			}

			if (textBox8.Text != "") {
				double principal = double.Parse(textBox1.Text);
				double investmentTotalDateNum = getValueDateToDueDate();
				double investmentRemainDateNum = GetTransferDateToDueDate();
				double remainInterest = double.Parse(textBox5.Text);
				double investorBenefit = double.Parse(textBox8.Text);
				double tmp = investorBenefit * investmentRemainDateNum / investmentTotalDateNum;
				double discountGold = 0;
				discountGold = (tmp*principal-remainInterest)/(tmp+1);
				textBox6.Text = discountGold.ToString("0.00");

				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox4.Text == "" ||
				textBox5.Text == "" ||
				textBox6.Text == "") {
				return;
			}

			double investorBenefit = double.Parse(textBox8.Text);
			double discountGold = double.Parse(textBox6.Text);
			double principal = double.Parse(textBox1.Text);
			double investmentTotalDateNum = getValueDateToDueDate();
			double investmentDateNum = getValueDateToTransferDate();

			textBox7.Text = (((investorBenefit - discountGold - calcPoundage()) / principal) * (365 / investmentDateNum)).ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox4.Text == "" ||
				textBox5.Text == "" ||
				textBox6.Text == "") {
				return;
			}

			double remainInterest = double.Parse(textBox5.Text);
			double discountGold = double.Parse(textBox6.Text);
			double principal = double.Parse(textBox1.Text);
			double investmentTotalDateNum = getValueDateToDueDate();
			double investmentRemainDateNum = GetTransferDateToDueDate();

			textBox8.Text = (((remainInterest+discountGold)/(principal+-discountGold))*(365/investmentRemainDateNum)).ToString();
		}

		// 初始化按钮的Click事件
		private void button4_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			textBox7.Text = "";
			textBox8.Text = "";

		}

		private void calcInterest()
		{
			if (textBox1.Text != "" &&
				textBox3.Text != "") {
				double principle = double.Parse(textBox1.Text);
				if (principle > 0.0) {
					double gainInterest = GetActualInterestDays() * GetDailyInterestRate() * principle;
					double totalInterest = getInterest(dateTimePicker1.Value, getValueDateToDueDate());
					textBox4.Text = gainInterest.ToString("0.00");
					textBox5.Text = (totalInterest - gainInterest).ToString("0.00");
				}
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private int GetActualInterestDays()
		{
			DateTime startTime = dateTimePicker1.Value;
			int totalDays = getValueDateToTransferDate();
			int actualDaysTmp = 0;
			int actualDays = 0;
			int monthBegin = startTime.Month;

			while (true) {
				switch (startTime.Month) {
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					actualDaysTmp += 31;
					totalDays -= 31;
					break;
				case 4:
				case 6:
				case 9:
				case 11:
					actualDaysTmp += 30;
					totalDays -= 30;
					break;
				case 2:
					if (DateTime.IsLeapYear(startTime.Year)) {
						actualDaysTmp += 29;
						totalDays -= 29;
					} else {
						actualDaysTmp += 28;
						totalDays -= 28;
					}
					break;
				}
				if (totalDays >= 0) {
					startTime = startTime.AddMonths(1);
					actualDays = actualDaysTmp;
				} else {
					break;
				}
			}
			return actualDays;
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			if (textBox4.Text == "") {
				return;
			}

			double interest = double.Parse(textBox4.Text);
			if (textBox1.Text != "") {
				double principle = double.Parse(textBox1.Text);
				if (principle > 0.0)
				{
					double dailyInterestRate = interest / (GetActualInterestDays() * principle);
					textBox3.Text = (dailyInterestRate * 365 * 100).ToString("0.00");
				} else {
					return;
				}
			} else if (textBox3.Text != "") {
				double dailyInterestRate = GetDailyInterestRate();
				if (dailyInterestRate > 0.0) {
					textBox1.Text = (interest / dailyInterestRate / GetActualInterestDays()).ToString("0.00");
				} else {
					return;
				}
			}
			double totalInterest = getInterest(dateTimePicker1.Value, getValueDateToDueDate());
			textBox5.Text = (totalInterest - interest).ToString("0.00");
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			if (textBox5.Text == "") {
				return;
			}

			double remainInterest = double.Parse(textBox5.Text);
			if (textBox1.Text != "")
			{
				double principle = double.Parse(textBox1.Text);
				if (principle > 0.0) {
					double dailyInterestRate = remainInterest / ((getValueDateToDueDate() - GetActualInterestDays()) * principle);
					textBox3.Text = (dailyInterestRate * 365 * 100).ToString("0.00");
				} else {
					return;
				}
			} else if (textBox3.Text != "") {
				double dailyInterestRate = GetDailyInterestRate();
				if (dailyInterestRate > 0.0)
				{
					textBox1.Text = (remainInterest / (dailyInterestRate * (getValueDateToDueDate() - GetActualInterestDays()))).ToString("0.00");
				} else {
					return;
				}
			}
			double totalInterest = getInterest(dateTimePicker1.Value, getValueDateToDueDate());
			textBox4.Text = (totalInterest - remainInterest).ToString("0.00");
		}
	}
}
