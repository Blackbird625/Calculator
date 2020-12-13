using System;
using System.Globalization;
using Calculator.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorPage : ContentPage
	{
		public CalculatorPage()
		{
			InitializeComponent();
		}

		private void ClearEntryValue_OnClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				EntryValue.Text = string.Empty;
			}

			// Long press: https://alexdunn.org/2017/12/27/xamarin-tip-xamarin-forms-long-press-effect/
		}

		private void InverseSign_OnClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				EntryValue.Text = EntryValue.Text[0] == App.DecimalSeparator ? EntryValue.Text[1..] : App.DecimalSeparator + EntryValue.Text;
			}
		}

		private void DecimalSeparator_OnClicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				if (EntryValue.Text.Contains(App.DecimalSeparator))
				{
					return;
				}
				EntryValue.Text += App.DecimalSeparator;
			}
		}

		private void DigitButton_OnClicked(object sender, EventArgs e)
		{
			if (sender is Button button)
			{
				EntryValue.Text += button.Text;
			}
		}

		private void Operation_OnClicked(object sender, EventArgs e)
		{
			DigitButton_OnClicked(sender, e);
		}

		private void OpenBrace_OnClicked(object sender, EventArgs e)
		{
			DigitButton_OnClicked(sender, e);
		}

		private void CloseBrace_OnClicked(object sender, EventArgs e)
		{
			DigitButton_OnClicked(sender, e);
		}

		private void EvaluateExpression_OnClick(object sender, EventArgs e)
		{
			if (sender is Button button)
			{
				string expression = EntryValue.Text;
				EntryValue.Text += button.Text;
				Expression.Text = EntryValue.Text;
				EntryValue.Text = MathExpression.TryParse(expression, out var result)
					? result.ToString(CultureInfo.InvariantCulture)
					: "Invalid expression";
			}
		}
	}
}