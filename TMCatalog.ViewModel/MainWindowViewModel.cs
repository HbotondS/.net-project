// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.ViewModel
{
  using TMCatalog.Common.MVVM;
  using TMCatalog.Logic;
    using TMCatalog.ViewModel;
    using TMCatalog.ViewModel.UserControlls;
    using TMCatalogClient.Model;

    public class MainWindowViewModel : ViewModelBase
    {

        public static CatalogController CatalogController;

        public MainWindowViewModel()
        {
            CatalogController = new CatalogController();
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.VehicleSearchViewModel = new VehicleSearchViewModel();
            this.ArticleViewModel = new ArticleViewModel();
            Instance = this;
        }

        public RelayCommand CloseCommand { get; set; }

        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }
        private VehicleSearchViewModel vehicleSearchViewModel;

        public VehicleSearchViewModel VehicleSearchViewModel
        {
            get { return this.vehicleSearchViewModel; }
            set {
                this.vehicleSearchViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public static MainWindowViewModel Instance { get; set; }
        public void SetVehicleTypeToArticle(VehicleType vehicleType)
        {
            this.ArticleViewModel.VehicleType = vehicleType;

        }
        private ArticleViewModel articleViewModel;

        public ArticleViewModel ArticleViewModel
        {
            get { return articleViewModel; }
            set { articleViewModel = value; }
        }


    }
}
