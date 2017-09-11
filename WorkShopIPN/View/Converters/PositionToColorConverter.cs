using System;
using System.Globalization;
using WorkShopIPN.Model;
using Xamarin.Forms;

namespace WorkShopIPN
{
	public class PositionToColorConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			JobPosition position = (JobPosition)value;
			Color color;
			switch (position)
			{
				case JobPosition.Excecutive:
					color = Color.Red;
					break;
				case JobPosition.Operator:
                    color = Color.Brown;
					break;
				case JobPosition.Supervisor:
					color = Color.Green;
					break;
                case JobPosition.Developer:
                    color = Color.DarkRed;
                    break;
                case JobPosition.TechnicalSupport:
                    color = Color.DarkMagenta;
                    break;
				default:
					color = Color.Gray;
					break;
			}
			return color;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

