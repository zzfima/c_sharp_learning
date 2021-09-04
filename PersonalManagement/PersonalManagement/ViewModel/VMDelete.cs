using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class VMDelete
    {
        private ICommand _deleteCommand;
        private ServiceProvider _serviceProvider;
        private ObservableCollection<PersonExport> _persons;
        private PersonExport _selectedPerson;

        public VMDelete(ServiceProvider serviceProvider,
            ObservableCollection<PersonExport> persons,
            PersonExport selectedPerson)
        {
            _serviceProvider = serviceProvider;
            _persons = persons;
            _selectedPerson = selectedPerson;
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new CommandHandler(
                    () => DeleteAction(), true));
            }
        }

        public void DeleteAction()
        {
            PersonExport personExportToDelete = _selectedPerson;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            _persons.Remove(personExportToDelete);
        }
    }
}