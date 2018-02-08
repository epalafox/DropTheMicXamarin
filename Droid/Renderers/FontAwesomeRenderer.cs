using Android.Graphics;
using DropTheMic.Common.Views.Shared.FontAwesome;
using DropTheMic.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0618 // Type or member is obsolete
[assembly: ExportRenderer(typeof(FontAwesome), typeof(FontAwesomeRenderer))]
namespace DropTheMic.Droid.Renderers
{
	public class FontAwesomeRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				//The ttf in /Assets is CaseSensitive, so name it FontAwesome.ttf
				Control.Typeface = Typeface.CreateFromAsset(Context.Assets, "Fonts/" + FontAwesome.Typeface + ".ttf");
			}
		}
	}
}

#pragma warning restore CS0618 // Type or member is obsolete