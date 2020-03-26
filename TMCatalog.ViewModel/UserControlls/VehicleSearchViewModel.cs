using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalogClient.Model;

namespace TMCatalog.ViewModel.UserControlls
{
    public class VehicleSearchViewModel : ViewModelBase
    {
        public VehicleSearchViewModel()
        {
            this.Manufacturers = Data.Catalog.GetManufacturers();
            this.OpenArticleTabCommand = new RelayCommand(this.OpenArticleTabExecute);


        }
        private List<Manufacturer> manifacturers;
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
        public List<Manufacturer> Manufacturers
        {
            get
            {
                return this.manifacturers;
            }

            set
            {
                this.manifacturers = value;
                this.RaisePropertyChanged();
            }
        }
        private List<VehicleType> vehicleTypes;

        public List<VehicleType> VehicleTypes
        {
            get { return vehicleTypes; }
            set { vehicleTypes = value;
                this.RaisePropertyChanged();
            }
        }

        private int manufactureId;

        public int ManufacturerId
        {
            get
            {
                return this.manufactureId;
            }
            set
            {
                this.manufactureId = value;
                this.Models = Data.Catalog.GetModels(this.ManufacturerId); // v value


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

        private void OpenArticleTabExecute()
        {
            this.TabIndex = 1;
            MainWindowViewModel.Instance.SetVehicleTypeToArticle(this.SelectedVehicleType);

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
       


        public VehicleType MyProperty
        {
            get { return SelectedVehicleType; }
            set { SelectedVehicleType = value; }
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

       public RelayCommand OpenArticleTabCommand
        {
            get;set;
        }     
    }
}
