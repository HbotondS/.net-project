using System.Collections.Generic;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalogClient.Model;
using TMCatalog.Common.Interfaces.TMCatalogContents;

namespace TMCatalog.ViewModel.UserControlls
{
    public class VehicleSearchViewModel : ViewModelBase, IVehicleSearchContent
    {
        public string Header => "Vehicle Search";

        public RelayCommand OpenArticleTabCommand
        {
            get; set;
        }

        public VehicleSearchViewModel()
        {
            this.Manufacturers = Data.Catalog.GetManufacturers();
            this.OpenArticleTabCommand = new RelayCommand(this.OpenArticleTabExecute);
        }
        private List<Manufacturer> manufacturers;
        public List<Manufacturer> Manufacturers
        {
            get
            {
                return this.manufacturers;
            }

            set
            {
                this.manufacturers = value;
                this.RaisePropertyChanged();
            }
        }

        private List<TMCatalogClient.Model.Model> models;
        public List<TMCatalogClient.Model.Model> Models
        {
            get { return models; }
            set
            {
                models = value;
                this.RaisePropertyChanged();
            }
        }

        private List<VehicleType> vehicleTypes;
        public List<VehicleType> VehicleTypes
        {
            get { return vehicleTypes; }
            set
            {
                vehicleTypes = value;
                this.RaisePropertyChanged();
            }
        }

        private int manufacturerId;
        public int ManufacturerId
        {
            get
            {
                return this.manufacturerId;
            }
            set
            {
                this.manufacturerId = value;
                this.Models = Data.Catalog.GetModels(this.ManufacturerId);
                this.RaisePropertyChanged();
            }
        }

        private int modelId;
        public int ModelId
        {
            get
            {
                return this.modelId;
            }
            set
            {
                this.modelId = value;
                this.VehicleTypes = Data.Catalog.GetVehicleTypes(this.modelId);
                this.RaisePropertyChanged();
            }
        }

        private VehicleType selectedVehicleType;
        public VehicleType SelectedVehicleType
        {
            get
            {
                return this.selectedVehicleType;
            }
            set
            {
                this.selectedVehicleType = value;
                this.RaisePropertyChanged();
            }
        }

        private int tabIndex;
        public int TabIndex
        {
            get => tabIndex;
            set
            {
                tabIndex = value;
                this.RaisePropertyChanged();
            }
        }

        public VehicleType MyProperty
        {
            get { return SelectedVehicleType; }
            set { SelectedVehicleType = value; }
        }

        private void OpenArticleTabExecute()
        {
            this.TabIndex = 1;
            MainWindowViewModel.Instance.SetVehicleTypeToArticle(this.SelectedVehicleType);

        }
    }
}
