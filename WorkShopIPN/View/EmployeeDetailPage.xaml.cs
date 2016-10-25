using System;
using System.Collections.Generic;
using WorkShopIPN.Model;
using WorkShopIPN.ViewModel;
using Xamarin.Forms;

namespace WorkShopIPN
{
	public partial class EmployeeDetailPage : ContentPage
	{
		public EmployeeDetailPage(Employee employee)
		{
			InitializeComponent();
			this.BindingContext = new EmployeeVM(employee);
		}


	}
}
