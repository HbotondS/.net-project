using TMCatalog.Common.MVVM;

namespace TMCatalog.Common.Interfaces.TMCatalogContents
{
    public interface IClosableContent
    {
        RelayCommand CloseCommand { get; }
    }
}
