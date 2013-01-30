using System.Windows;
using System.Windows.Controls;
using MathParser;
using MathParser.UI;

namespace ParserApp
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		Parser p = new Parser();
		private void inputTb_TextChanged(object sender, TextChangedEventArgs e)
		{
			RichTextBox source = (RichTextBox)sender;

			string text = TextHelper.GetText(source.Document);
			try
			{
				if (text.Length > 0)
				{
					outputTb.Text = p.Parse(text).Tree.ToPolishInversedNotationString();
				}
			}
			catch (ParserException exc)
			{
				outputTb.Text = exc.Message;
			}
		}
	}
}
