using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalogClient.Model;
using TMCatalog.Common.Interfaces.TMCatalogContents;
using TMCatalog.Logic;

namespace TMCatalog.ViewModel.UserControlls
{
    public class ArticleViewModel: ViewModelBase, IArticleContent
    {
        public string Header => this.VehicleType.Description;

        public RelayCommand CloseCommand { get; }

        private VehicleType vehicleType;

        public VehicleType VehicleType
        {
            get => vehicleType;
            set
            {
                vehicleType = value;
                this.RaisePropertyChanged();
            }
        }

        public ArticleViewModel(VehicleType vehicleType)
        {
            this.VehicleType = vehicleType;
            this.CloseCommand = new RelayCommand(this.CloseExecute);
        }

        private void CloseExecute()
        {
            MainWindowViewModel.Instance.CloseArticle(this);
        }
    }
}
