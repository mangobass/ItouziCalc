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
			//InitForTest();
		}

		private void InitForTest()
		{
			this.dateTimePickerValueDay.Value = new System.DateTime(2013, 12, 10);
			this.dateTimePickerDueDay.Value = new System.DateTime(2014, 10, 9);
			this.textBoxPrincipal.Text = "10000";
			this.textBoxGainInterestDayPerMonth.Text = "31";
			this.textBoxInterestRate.Text = "14";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private double GetDailyInterest()
		{
			return double.Parse(textBoxPrincipal.Text) * double.Parse(textBoxInterestRate.Text) / 100.0 / 365;
		}

		// 判断输入的字符是否是数字或点（点只能出现一次），是的话返回true，不然返回false
		private bool checkTextBoxNumberInput(TextBox obj, char c)
		{
			if ((c < 48 || c > 57) && c != 46 && c != 8)
			{
				return false;
			}

			// 已经输入过"."或者没有输入过任何数字的话，也返回false
			if (c == 46 && (obj.Text.Length == 0 || obj.Text.Contains('.')))
			{
				return false;
			}

			return true;
		}

		// 计算手续费
		private double calcPoundage()
		{
			double principle = 0.0;
			float poundageRate = 0.0F;

			if (double.TryParse(textBoxPrincipal.Text, out principle) && float.TryParse(textBoxPoundage.Text, out poundageRate))
			{
				return principle * poundageRate / 100.0;
			}
			return 0.0;
		}

		// value date   due date    transfer date
		private int getValueDateToDueDate()
		{
			DateTime tmValueDate = dateTimePickerValueDay.Value;
			String valueDate = tmValueDate.Month.ToString() + "/" + tmValueDate.Day.ToString() + "/" + tmValueDate.Year.ToString() + " 00:00:00";
			DateTime newTmValueDate = DateTime.Parse(valueDate);

			DateTime tmDueDate = dateTimePickerDueDay.Value;
			String dueDate = tmDueDate.Month.ToString() + "/" + tmDueDate.Day.ToString() + "/" + tmDueDate.Year.ToString() + " 00:00:00";
			DateTime newTmDueDate = DateTime.Parse(dueDate);

			TimeSpan tmSpan = newTmDueDate.Subtract(newTmValueDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private int getValueDateToTransferDate()
		{
			DateTime tmValueDate = dateTimePickerValueDay.Value;
			String valueDate = tmValueDate.Month.ToString() + "/" + tmValueDate.Day.ToString() + "/" + tmValueDate.Year.ToString() + " 00:00:00";
			DateTime newTmValueDate = DateTime.Parse(valueDate);

			DateTime tmTransferDate = dateTimePickerTransferDay.Value;
			String transferDate = tmTransferDate.Month.ToString() + "/" + tmTransferDate.Day.ToString() + "/" + tmTransferDate.Year.ToString() + " 00:00:00";
			DateTime newTmTransferDate = DateTime.Parse(transferDate);

			TimeSpan tmSpan = newTmTransferDate.Subtract(newTmValueDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private int GetTransferDateToDueDate()
		{
			DateTime tmTransferDate = dateTimePickerTransferDay.Value;
			String transferDate = tmTransferDate.Month.ToString() + "/" + tmTransferDate.Day.ToString() + "/" + tmTransferDate.Year.ToString() + " 00:00:00";
			DateTime newTmTransferDate = DateTime.Parse(transferDate);

			DateTime tmDueDate = dateTimePickerDueDay.Value;
			String dueDate = tmDueDate.Month.ToString() + "/" + tmDueDate.Day.ToString() + "/" + tmDueDate.Year.ToString() + " 00:00:00";
			DateTime newTmDueDate = DateTime.Parse(dueDate);

			TimeSpan tmSpan = newTmDueDate.Subtract(newTmTransferDate);

			return tmSpan.Days < 0 ? 0 : tmSpan.Days;
		}

		private void dateTimePickerValueDay_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void dateTimePickerDueDay_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void dateTimePickerTransferDay_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBoxPrincipal_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxPrincipal, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxPoundage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxPoundage, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxInterestRate_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxInterestRate, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxRemainInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxRemainInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxTotalInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!checkTextBoxNumberInput(textBoxTotalInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void calcDiscountGoldByCreditorBenifit()
		{
			double principal = double.Parse(textBoxPrincipal.Text);
			double investmentDateNum = getValueDateToTransferDate();
			double interest = double.Parse(textBoxInterest.Text);
			double creditorBenefitRate = double.Parse(textBoxCreditorBenefitRate.Text) / 100.0;
			double discountGold = 0;
			discountGold = -((creditorBenefitRate * investmentDateNum / 365) * principal - interest + calcPoundage());
			textBoxDiscountGold.Text = discountGold.ToString("0.00");
		}

		private void calcDiscountGoldByInvestorBenifit()
		{
			double principal = double.Parse(textBoxPrincipal.Text);
			double investmentRemainDateNum = GetTransferDateToDueDate();
			double remainInterest = double.Parse(textBoxRemainInterest.Text);
			double investorBenefitRate = double.Parse(textBoxInvestorBenefitRate.Text) / 100.0;
			double tmp = investorBenefitRate * investmentRemainDateNum / 365;
			double discountGold = 0;
			discountGold = (tmp * principal - remainInterest) / (tmp + 1);
			textBoxDiscountGold.Text = discountGold.ToString("0.00");
		}

		private void calcCreditorBenefitRate()
		{
			double interest = double.Parse(textBoxInterest.Text);
			double discountGold = double.Parse(textBoxDiscountGold.Text);
			double principal = double.Parse(textBoxPrincipal.Text);
			double investmentTotalDateNum = getValueDateToDueDate();
			double investmentDateNum = getValueDateToTransferDate();

			textBoxCreditorBenefitRate.Text = ((((interest - discountGold - calcPoundage()) / principal) * (365 / investmentDateNum)) * 100.0).ToString("0.00");
		}

		private void calcInvestorBenefitRate()
		{
			double remainInterest = double.Parse(textBoxRemainInterest.Text);
			double discountGold = double.Parse(textBoxDiscountGold.Text);
			double principal = double.Parse(textBoxPrincipal.Text);
			double investmentTotalDateNum = getValueDateToDueDate();
			double investmentRemainDateNum = GetTransferDateToDueDate();

			textBoxInvestorBenefitRate.Text = ((((remainInterest + discountGold) / (principal - discountGold)) * (365 / investmentRemainDateNum)) * 100.0).ToString("0.00");
		}

		private void buttonCalcByDiscountGold_Click(object sender, EventArgs e)
		{
			if (textBoxInterest.Text == "" ||
				textBoxRemainInterest.Text == "")
			{
				return;
			}

			calcCreditorBenefitRate();
			calcInvestorBenefitRate();
		}

		private void buttoCalcByCreditorBenefitRate_Click(object sender, EventArgs e)
		{
			if (textBoxInterest.Text == "" ||
				textBoxRemainInterest.Text == "")
			{
				return;
			}

			calcDiscountGoldByCreditorBenifit();
			calcInvestorBenefitRate();
		}

		private void buttonCalcByInvestorBenefitRate_Click(object sender, EventArgs e)
		{
			if (textBoxInterest.Text == "" ||
				textBoxRemainInterest.Text == "")
			{
				return;
			}

			calcDiscountGoldByInvestorBenifit();
			calcCreditorBenefitRate();
		}

		// 初始化按钮的Click事件
		private void buttonReset_Click(object sender, EventArgs e)
		{
			textBoxPrincipal.Text = "";
			textBoxInterestRate.Text = "";
			textBoxInterest.Text = "";
			textBoxRemainInterest.Text = "";
			textBoxDiscountGold.Text = "";
			textBoxCreditorBenefitRate.Text = "";
			textBoxInvestorBenefitRate.Text = "";
			textBoxTotalInterest.Text = "";

			dateTimePickerValueDay.ResetText();
			dateTimePickerDueDay.ResetText();
			dateTimePickerTransferDay.ResetText();
		}

		private double getTotalInterest()
		{
			double principle = double.Parse(textBoxPrincipal.Text);
			return (principle * double.Parse(textBoxInterestRate.Text) / 100.0) / 365 * getValueDateToDueDate();
		}

		private void calcInterest()
		{
			if (textBoxPrincipal.Text != "" &&
				textBoxInterestRate.Text != "" &&
				textBoxGainInterestDayPerMonth.Text != "")
			{
				double principle = double.Parse(textBoxPrincipal.Text);
				if (principle > 0.0)
				{
					double gainInterest = getGainInterest();
					double totalInterest = getTotalInterest();
					textBoxTotalInterest.Text = totalInterest.ToString("0.00");
					textBoxInterest.Text = gainInterest.ToString("0.00");
					textBoxRemainInterest.Text = (totalInterest - gainInterest).ToString("0.00");
				}
			}
		}

		private double getGainInterest()
		{
			List<InterestPaymentInfo> monthlyInterestInfoList = GetInterestPaymentInfoTable();
			double totalInterest = 0.0;
			foreach (InterestPaymentInfo item in monthlyInterestInfoList)
			{
				if ((item.m_InterestPaymentDate.Subtract(dateTimePickerTransferDay.Value)).Days <= 0)
				{
					totalInterest += item.m_InterestValue;
				}
			}
			return totalInterest;
		}

		private void textBoxPrincipal_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBoxPoundage_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBoxInterestRate_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private void textBoxGainInterestDayPerMonth_Leave(object sender, EventArgs e)
		{
			calcInterest();
		}

		private int GetDaysByYearMonth(int year, int month)
		{
			switch (month)
			{
			case 2:
				if (DateTime.IsLeapYear(year)) {
					return 29;
				} else {
					return 28;
				}
			case 1:
			case 3:
			case 5:
			case 7:
			case 8:
			case 10:
			case 12:
				return 31;
			case 4:
			case 6:
			case 9:
			case 11:
				return 30;
			default:
				Assert(false);
				return 0;
			}
		}

		private void Assert(bool b)
		{
			if (!b) {
				int aa = 0;
				int bb = 0;
				aa = aa / bb;
			}
		}

		List<DateTime> GetInterestPaymentDateTable()
		{
			DateTime valueDate = dateTimePickerValueDay.Value; //起息日
			DateTime repaymentDate = dateTimePickerDueDay.Value; //还款日
			int interestPaymentDayPerMonth = int.Parse(textBoxGainInterestDayPerMonth.Text); //月还息日
			DateTime interestPaymentDate = GetNextInterestPaymentDate(valueDate, interestPaymentDayPerMonth, repaymentDate);
			List<DateTime> interestPaymentDateTable = new List<DateTime>();
			if (interestPaymentDate.Subtract(repaymentDate).Days < 0)
			{
				interestPaymentDateTable.Add(interestPaymentDate);
			}
			while (interestPaymentDate.Subtract(repaymentDate).Days < 0)
			{
				interestPaymentDate = GetNextInterestPaymentDate(interestPaymentDate, interestPaymentDayPerMonth, repaymentDate);
				interestPaymentDateTable.Add(interestPaymentDate);
			}
			return interestPaymentDateTable;
		}

		DateTime GetNextInterestPaymentDate(DateTime lastInterestPaymentDate, int interestPaymentDayPerMonth, DateTime repaymentDate)
		{
			DateTime r = ReplaceMonthDay(lastInterestPaymentDate, interestPaymentDayPerMonth);

			while (r.Subtract(lastInterestPaymentDate).Days < 15)
			{
				DateTime nextMonthDate = r.AddMonths(1);
				r = ReplaceMonthDay(nextMonthDate, interestPaymentDayPerMonth);
			}

			if (Abs(r.Subtract(repaymentDate).Days) < 15)
				return repaymentDate;
			else
				return r;
		}

		private int Abs(int num)
		{
			if (num < 0)
				return -num;
			return num;
		}

		private DateTime ReplaceMonthDay(DateTime date, int day)
		{
			int monthDays = GetDaysByYearMonth(date.Year, date.Month);
			return new System.DateTime(date.Year, date.Month, day > monthDays ? monthDays : day < 1 ? 1 : day);
		}

		struct InterestPaymentInfo
		{
			public DateTime m_InterestPaymentDate;
			public double m_InterestValue;
		};

		List<InterestPaymentInfo> GetInterestPaymentInfoTable()
		{
			List<InterestPaymentInfo> interestPaymentInfoTable = new List<InterestPaymentInfo>();
			List<DateTime> interestPaymentDateTable = GetInterestPaymentDateTable();
			DateTime lastInterestPaymentDate = (dateTimePickerValueDay.Value).AddDays(-1); //起息日 , -1日?

			foreach (DateTime item in interestPaymentDateTable)
			{
				InterestPaymentInfo interestPaymentInfo;
				interestPaymentInfo.m_InterestPaymentDate = item;
				interestPaymentInfo.m_InterestValue = CalcInterestValue(item.Subtract(lastInterestPaymentDate).Days);
				interestPaymentInfoTable.Add(interestPaymentInfo);

				lastInterestPaymentDate = item;
			}
			return interestPaymentInfoTable;
		}

		private double CalcInterestValue(int days)
		{
			return GetDailyInterest() * days;
		}
	}
}
