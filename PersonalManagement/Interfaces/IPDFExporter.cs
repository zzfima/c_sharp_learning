using System.Collections.ObjectModel;

namespace Interfaces
{
    public interface IPDFExporter<T>
    {
        void Export(ObservableCollection<T> persons);
    }
}
