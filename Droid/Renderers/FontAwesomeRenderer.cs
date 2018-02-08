using Android.Graphics;
using DropTheMic.Common.Views.Shared.FontAwesome;
using DropTheMic.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0618 // Type or member is obsolete
[assembly: ExportRenderer(typeof(FontAwesomeBrands), typeof(FontAwesomeBrandsRenderer))]
namespace DropTheMic.Droid.Renderers
{
	public class FontAwesomeBrandsRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				//The ttf in /Assets is CaseSensitive, so name it FontAwesome.ttf
				Control.Typeface = Typeface.CreateFromAsset(Context.Assets, FontAwesomeBrands.Typeface + ".ttf");
			}
		}
	}
}

#pragma warning restore CS0618 // Type or member is obsolete