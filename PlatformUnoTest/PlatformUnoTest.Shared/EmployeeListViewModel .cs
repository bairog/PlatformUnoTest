using System.Collections.ObjectModel;
using PlatformUnoTest.DAL;

namespace PlatformUnoTest
{
    public class EmployeeListViewModel
    {
        private ObservableCollection<Employee> _employee = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }


        public EmployeeListViewModel()
        {
            Employee = new ObservableCollection<Employee>(StorageSystem.GetAllEmployee());
        }
    }
}
