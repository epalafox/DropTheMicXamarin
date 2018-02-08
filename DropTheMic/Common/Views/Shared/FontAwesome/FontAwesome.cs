using System;
using Xamarin.Forms;

namespace DropTheMic.Common.Views.Shared.FontAwesome
{
	public class FontAwesomeSolid : Label
	{
		//Must match the exact "Name" of the font which you can get by double clicking the TTF in Windows
		public const string Typeface = "FontAwesomeSolid";
		public FontAwesomeSolid()
		{
			FontFamily = Typeface;
		}
		public FontAwesomeSolid(string fontAwesomeIcon = null)
		{
			FontFamily = Typeface;    //iOS is happy with this, Android needs a renderer to add ".ttf"
			Text = fontAwesomeIcon;
		}
	}
}
