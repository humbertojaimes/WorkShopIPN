using WorkShopIPN.Model;
using Xamarin.Forms;

namespace WorkShopIPN
{
	public partial class WorkShopIPNPage : ContentPage
	{
		public WorkShopIPNPage()
		{
			InitializeComponent();
			this.BindingContext = new DirectoryVM();
			LvEmployees.ItemSelected += LvEmployees_ItemSelected;
		}

		async void LvEmployees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var employee = e.SelectedItem as Employee;
			if (employee == null)
				return;

			await Navigation.PushAsync(new EmployeeDetailPage(employee));

			LvEmployees.SelectedItem = null;
		}
	}
}
