using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WorkShopIPN.Communication;
using WorkShopIPN.Storage;

namespace WorkShopIPN.Model
{
	public class EmployeeDirectory
	{
		string _path;
		public EmployeeDirectory()
		{	
			
		}

		public async Task GenerateRandomDirectory()
		{
            try
            {
                DataBaseManager databaseManager = new DataBaseManager();
                Employees = new ObservableCollection<Employee>();
                Random rdn = new Random();
                string[] photos =
                {
			//"http://www.femside.com/wp-content/uploads/2013/06/suit-woman.jpg",
			//	"http://previews.123rf.com/images/phakimata/phakimata1103/phakimata110300023/9030612-Experienced-female-business-lawyer-in-suit-Beautiful-Senior-old-woman-with-arms-crossed-isolated--Stock-Photo.jpg",
			//	"https://angrymiddleagewoman.files.wordpress.com/2011/12/woman-in-suit.jpg",
				"http://steezo.com/wp-content/uploads/2012/12/man-in-suit2.jpg",
                "http://attractmen.org/wp-content/uploads/2015/10/attractmen.org-libra-men.jpg",
            };
                ImageClient client = new ImageClient();
                for (int i = 0; i < 16; i++)
                {
                    var name = "Nombre" + i;
                    var photo = photos[rdn.Next(0, 2)];
                    var newEmployee = new Employee(
                        name,
                        await client.GetImage(photo),
                        (JobPosition)rdn.Next(0, 4),
                        name + "@mycompany.com"
                    );
                    Employees.Add(newEmployee);
                    await databaseManager.SaveValueAsync<Employee>(newEmployee);
                }
            }catch(Exception e)
            {
                
            }

		}

		public ObservableCollection<Employee> Employees
		{
			get;
			set;
		}

	}

}

