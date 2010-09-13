using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathParser;
using MathParser.TextModel;

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
