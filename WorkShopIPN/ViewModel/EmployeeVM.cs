using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Media;
using WorkShopIPN.Model;
using WorkShopIPN.Storage;
using Xamarin.Forms;

namespace WorkShopIPN.ViewModel
{
	public class EmployeeVM : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged = delegate
		{

		};

		void RaiseProperty([CallerMemberName]string propertyName = "")
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				RaiseProperty();
			}
		}

		ObservableCollection<Employee> employees;
		public ObservableCollection<Employee> Employees
		{
			get { return employees; }
			set { employees = value; RaiseProperty(); }
		}

		Employee selectedEmployee;
		public Employee SelectedEmployee
		{
			get { return selectedEmployee; }
			set { selectedEmployee = value; RaiseProperty(); }
		}

		public Command TakePhotoCommand
		{
			get;
			set;
		}

		public Command SaveEmployeeCommand
		{
			get;
			set;
		}

		DataBaseManager databaseManager;


		public EmployeeVM(Employee employee)
		{
			databaseManager = new DataBaseManager();
			TakePhotoCommand = new Command(() => TakePhoto(),
												 () => !IsBusy);
			SaveEmployeeCommand = new Command(() => SaveEmployee(),
												 () => !IsBusy);
			SelectedEmployee = employee;
		}

        async Task SaveEmployee()
		{
            await databaseManager.SaveValueAsync<Employee>(SelectedEmployee);
		}

		async Task TakePhoto()
		{

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				Directory = "Sample",
				Name = "test.jpg"
			});

			if (file == null)
				return;

			byte[] photo;
			using (MemoryStream ms = new MemoryStream())
			{
				file.GetStream().CopyTo(ms);
				photo = ms.ToArray();
			}

			SelectedEmployee.Photo = photo;
			await databaseManager.SaveValueAsync<Employee>(SelectedEmployee);
		}


	}
}


