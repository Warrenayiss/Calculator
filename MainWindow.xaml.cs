using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		double lastNum, result;
		selectedOperator selectedOperator;
		public MainWindow()
		{
			InitializeComponent();

			acBtn.Click += acBehaviour;
			negBtn.Click += negBehaviour;
			percentBtn.Click += PercentBtn_Click;
			equalBtn.Click += EqualBtn_Click;
		}

		private void OpeBtn_Click(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(resultLb.Content.ToString(), out lastNum))
			{
				resultLb.Content = "0";
			}
			if (sender == slashBtn)
			{
				selectedOperator = selectedOperator.Division;
			}
			if (sender == starBtn)
			{
				selectedOperator = selectedOperator.Multiplication;
			}
			if (sender == minusBtn)
			{
				selectedOperator = selectedOperator.Soustraction;
			}
			if (sender == plusBtn)
			{
				selectedOperator = selectedOperator.Addition;
			}
		}

		private void NumBtn_Click(object sender, RoutedEventArgs e)
		{
			int selectedValue = 0;

			if (sender == zeroBtn)
			{
				selectedValue = 0;
			}
			if (sender == oneBtn)
			{
				selectedValue = 1;
			}
			if (sender == twoBtn)
			{
				selectedValue = 2;
			}
			if (sender == threeBtn)
			{
				selectedValue = 3;
			}
			if (sender == fourBtn)
			{
				selectedValue = 4;
			}
			if (sender == fiveBtn)
			{
				selectedValue = 5;
			}
			if (sender == sixBtn)
			{
				selectedValue = 6;
			}
			if (sender == sevenBtn)
			{
				selectedValue = 7;
			}
			if (sender == eightBtn)
			{
				selectedValue = 8;
			}
			if (sender == nineBtn)
			{
				selectedValue = 9;
			}

			if (resultLb.Content.ToString() == "0")
			{
				resultLb.Content = $"{selectedValue}";
			}
			else
			{
				resultLb.Content = $"{ resultLb.Content}{selectedValue}";
			}
		}

		private void EqualBtn_Click(object sender, RoutedEventArgs e)
		{
			double newNum;
			if (double.TryParse(resultLb.Content.ToString(), out newNum))
			{
				switch (selectedOperator)
				{
					case selectedOperator.Addition:
						result = SimpleMath.Add(lastNum, newNum);
						break;
					case selectedOperator.Soustraction:
						result = SimpleMath.Sous(lastNum, newNum);
						break;
					case selectedOperator.Multiplication:
						result = SimpleMath.Multi(lastNum, newNum);
						break;
					case selectedOperator.Division:
						result = SimpleMath.Div(lastNum, newNum);
						break;
				}
			}
			resultLb.Content = result.ToString();
		}

		private void PercentBtn_Click(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(resultLb.Content.ToString(), out lastNum))
			{
				lastNum /= 100;
				resultLb.Content = lastNum.ToString();
			}
		}

		private void negBehaviour(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(resultLb.Content.ToString(), out lastNum))
			{
				lastNum *= -1;
				resultLb.Content = lastNum.ToString();
			}
		}

		private void dotBtn_Click(object sender, RoutedEventArgs e)
		{
			if (resultLb.Content.ToString().Contains("."))
			{
				//Do nothing
			}
			else
			{
				resultLb.Content = $"{ resultLb.Content}.";
			}
		}

		private void acBehaviour(object sender, RoutedEventArgs e)
		{
			resultLb.Content = "0";
		}
	}

	public enum selectedOperator
	{
		Addition,
		Soustraction,
		Multiplication,
		Division
	}
	public class SimpleMath 
	{
		public static double Add(double n1, double n2)
		{
			return n1 + n2;
		}
		public static double Sous(double n1, double n2)
		{
			return n1 - n2;
		}
		public static double Multi(double n1, double n2)
		{
			return n1 * n2;
		}
		public static double Div(double n1, double n2)
		{
			if (n2 == 0)
			{
				MessageBox.Show("Division by 0 not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
				return 0;
			}
			return n1 / n2;
		}
	}
}
