using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace WorkShopIPN
{
	public class ByteArrayToImageConverter:IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var photoArray = (Byte[])value;
			ImageSource imageSource = photoArray!=null?
				ImageSource.FromStream(() => new MemoryStream(photoArray)):
			               ImageSource.FromFile("PhotoIcon.jpg");
			return imageSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

