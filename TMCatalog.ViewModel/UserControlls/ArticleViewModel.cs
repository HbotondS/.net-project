using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalogClient.Model;

namespace TMCatalog.ViewModel.UserControlls
{
    public class ArticleViewModel :ViewModelBase
    {
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
    }
}
