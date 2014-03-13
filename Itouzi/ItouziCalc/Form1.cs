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
		private bool CheckTextBoxNumberInput(TextBox obj, char c)
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
		private double CalcPoundage()
		{
			double principle = 0.0;
			float poundageRate = 0.0F;

			if (double.TryParse(textBoxPrincipal.Text, out principle) && float.TryParse(textBoxPoundage.Text, out poundageRate))
			{
				return principle * poundageRate / 100.0;
			}
			return 0.0;
		}

		private void ClearInterestInfo()
		{
			textBoxInterest.Text = "";
			textBoxRemainInterest.Text = "";
			textBoxTotalInterest.Text = "";
		}

		// value date   due date    transfer date
		private int GetValueDateToDueDate()
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

		private int GetValueDateToTransferDate()
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

		private void textBoxPrincipal_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxPrincipal, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxPoundage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxPoundage, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxInterestRate_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxInterestRate, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxGainInterestDayPerMonth_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxGainInterestDayPerMonth, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxTotalInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxTotalInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBoxRemainInterest_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!CheckTextBoxNumberInput(textBoxRemainInterest, e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void CalcDiscountGoldByCreditorBenifit(double principal, double interest, double creditorBenefitRate)
		{
			double investmentDateNum = GetValueDateToTransferDate();
			double discountGold = 0;
			discountGold = -((creditorBenefitRate * investmentDateNum / 365) * principal - interest + CalcPoundage());
			textBoxDiscountGold.Text = discountGold.ToString("0.00");
		}

		private void CalcDiscountGoldByInvestorBenifit(double principal, double remainInterest, double investorBenefitRate)
		{
			double investmentRemainDateNum = GetTransferDateToDueDate();
			double tmp = investorBenefitRate * investmentRemainDateNum / 365;
			double discountGold = 0;
			discountGold = (tmp * principal - remainInterest) / (tmp + 1);
			textBoxDiscountGold.Text = discountGold.ToString("0.00");
		}

		private void CalcCreditorBenefitRate(double principal, double interest, double discountGold)
		{
			double investmentDateNum = GetValueDateToTransferDate();
			textBoxCreditorBenefitRate.Text = ((((interest - discountGold - CalcPoundage()) / principal) * (365 / investmentDateNum)) * 100.0).ToString("0.00");
		}

		private void CalcInvestorBenefitRate(double principal, double remainInterest, double discountGold)
		{
			double investmentRemainDateNum = GetTransferDateToDueDate();
			textBoxInvestorBenefitRate.Text = ((((remainInterest + discountGold) / (principal - discountGold)) * (365 / investmentRemainDateNum)) * 100.0).ToString("0.00");
		}

		private double GetTotalInterest()
		{
			double principle = double.Parse(textBoxPrincipal.Text);
			return (principle * double.Parse(textBoxInterestRate.Text) / 100.0) / 365 * GetValueDateToDueDate();
		}

		private bool IsBaseInfoSufficientToCalcInterest()
		{
			if (textBoxPrincipal.Text == "" ||
				textBoxInterestRate.Text == "" ||
				textBoxGainInterestDayPerMonth.Text == "")
			{
				return false;
			}
			return true;
		}

		private void CalcInterest()
		{
			double principle = double.Parse(textBoxPrincipal.Text);
			//if (principle > 0.0)
			{
				double gainInterest = GetGainInterest();
				double totalInterest = GetTotalInterest();
				textBoxTotalInterest.Text = totalInterest.ToString("0.00");
				textBoxInterest.Text = gainInterest.ToString("0.00");
				textBoxRemainInterest.Text = (totalInterest - gainInterest).ToString("0.00");
			}
		}

		private double GetGainInterest()
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

		private void dateTimePickerValueDay_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void dateTimePickerDueDay_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void dateTimePickerTransferDay_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxPrincipal_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxPoundage_Leave(object sender, EventArgs e)
		{

		}

		private void textBoxInterestRate_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxGainInterestDayPerMonth_Leave(object sender, EventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
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

		private double GetDiscountGold()
		{
			double discountGold = 0;
			if (!double.TryParse(textBoxDiscountGold.Text, out discountGold))
			{
				discountGold = 0;
			}
			return discountGold;
		}

		private double GetCreditorBenefitRate()
		{
			double creditorBenefitRate = 0;
			if (!double.TryParse(textBoxCreditorBenefitRate.Text, out creditorBenefitRate))
			{
				creditorBenefitRate = 0;
			}
			return creditorBenefitRate / 100.0;
		}

		private double GetInvestorBenefitRate()
		{
			double investorBenefitRate = 0;
			if (!double.TryParse(textBoxInvestorBenefitRate.Text, out investorBenefitRate))
			{
				investorBenefitRate = 0;
			}
			return investorBenefitRate / 100.0;
		}

		private bool IsBaseInfoSufficientToCalcAdvanceInfo()
		{
			if (textBoxPrincipal.Text == "" ||
				textBoxPoundage.Text == "" ||
				textBoxInterest.Text == "" ||
				textBoxRemainInterest.Text == ""
				)
			{
				return false;
			}
			return true;
		}

		private void textBoxDiscountGold_KeyUp(object sender, KeyEventArgs e)
		{
			if (!IsBaseInfoSufficientToCalcAdvanceInfo())
			{
				return;
			}

			if (textBoxDiscountGold.Text == "")
			{
				textBoxCreditorBenefitRate.Text = "";
				textBoxInvestorBenefitRate.Text = "";
				return;
			}

			CalcCreditorBenefitRate(double.Parse(textBoxPrincipal.Text),
									double.Parse(textBoxInterest.Text),
									GetDiscountGold());
			CalcInvestorBenefitRate(double.Parse(textBoxPrincipal.Text),
									double.Parse(textBoxRemainInterest.Text),
									GetDiscountGold());
		}

		private void textBoxCreditorBenefitRate_KeyUp(object sender, KeyEventArgs e)
		{
			if (!IsBaseInfoSufficientToCalcAdvanceInfo())
			{
				return;
			}

			if (textBoxCreditorBenefitRate.Text == "")
			{
				textBoxDiscountGold.Text = "";
				textBoxInvestorBenefitRate.Text = "";
				return;
			}

			CalcDiscountGoldByCreditorBenifit(double.Parse(textBoxPrincipal.Text),
											  double.Parse(textBoxInterest.Text),
											  GetCreditorBenefitRate());
			CalcInvestorBenefitRate(double.Parse(textBoxPrincipal.Text),
									double.Parse(textBoxRemainInterest.Text),
									GetDiscountGold());
		}

		private void textBoxInvestorBenefitRate_KeyUp(object sender, KeyEventArgs e)
		{
			if (!IsBaseInfoSufficientToCalcAdvanceInfo())
			{
				return;
			}

			if (textBoxInvestorBenefitRate.Text == "")
			{
				textBoxDiscountGold.Text = "";
				textBoxCreditorBenefitRate.Text = "";
				return;
			}

			CalcDiscountGoldByInvestorBenifit(double.Parse(textBoxPrincipal.Text),
											  double.Parse(textBoxRemainInterest.Text),
											  GetInvestorBenefitRate());
			CalcCreditorBenefitRate(double.Parse(textBoxPrincipal.Text),
									double.Parse(textBoxInterest.Text),
									GetDiscountGold());
		}

		private void textBoxPrincipal_KeyUp(object sender, KeyEventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxInterestRate_KeyUp(object sender, KeyEventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxGainInterestDayPerMonth_KeyUp(object sender, KeyEventArgs e)
		{
			if (IsBaseInfoSufficientToCalcInterest())
			{
				CalcInterest();
			}
		}

		private void textBoxInterest_KeyUp(object sender, KeyEventArgs e)
		{

		}

		private void textBoxRemainInterest_KeyUp(object sender, KeyEventArgs e)
		{

		}
	}
}
