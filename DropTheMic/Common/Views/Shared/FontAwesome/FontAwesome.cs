using System;
using Xamarin.Forms;

namespace DropTheMic.Common.Views.Shared.FontAwesome
{
	public class FontAwesome : Label
	{
		//Must match the exact "Name" of the font which you can get by double clicking the TTF in Windows
		public const string Typeface = "FontAwesome";
		public FontAwesome()
		{
			FontFamily = Typeface;
		}
		public FontAwesome(string fontAwesomeIcon = null)
		{
			FontFamily = Typeface;    //iOS is happy with this, Android needs a renderer to add ".ttf"
			Text = fontAwesomeIcon;
		}
	}
}
