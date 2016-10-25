using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WorkShopIPN.Model;
using WorkShopIPN.Storage;
using Xamarin.Forms;

namespace WorkShopIPN
{
	public class DirectoryVM: INotifyPropertyChanged
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



		public Command LoadDirectoryCommand
		{
			get;
			set;
		}



		DataBaseManager databaseManager;
		void LoadDirectory()
		{
			if (!IsBusy)
			{
				IsBusy = true;
				Employees =
					new ObservableCollection<Employee>(databaseManager.GetAllItems<Employee>());

				if (!Employees.Any())
				{
					EmployeeDirectory directory = new EmployeeDirectory();
					Employees = directory.Employees;
				}

				IsBusy = false;
			}
		}





		public DirectoryVM()
		{
			databaseManager = new DataBaseManager();
			LoadDirectory();
			LoadDirectoryCommand = new Command(() => LoadDirectory(),
												 () => !IsBusy);

		}

	}
}
