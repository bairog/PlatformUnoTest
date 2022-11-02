using System.Collections.ObjectModel;
using System.ComponentModel;
using PlatformUnoTest.DAL;

namespace PlatformUnoTest
{
    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private ObservableCollection<Employee> _employee = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employee
        {
            get { return _employee; }
            set 
            { 
                //_employee = value; 
                if(_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged("Employee");
                }
            }
        }


        public EmployeeListViewModel()
        {
            Employee = new ObservableCollection<Employee>(StorageSystem.GetAllEmployee());
        }
    }
}
