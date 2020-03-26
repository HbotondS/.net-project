// ------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogController.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.Logic
{
    using System.Collections.Generic;
    using TMCatalog.Model.DBContext;
    using TMCatalogClient.Model;
    using System.Linq;
    public class CatalogController
    {
        private TMCatalogDB catalogDatabase;

        public CatalogController()
        {
            this.catalogDatabase = new TMCatalogDB();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.catalogDatabase.Manufacturer.ToList();
        }

        public List<Model> GetModels(int manufacturerId)
        {
            //throw new System.NotImplementedException();
            return this.catalogDatabase.Models.Where(x => x.ManufacturerId == manufacturerId).ToList();
        }

        public List<VehicleType> GetVehicleTypes(int modelId)
            {

            return this.catalogDatabase.VehicleTypes.Include("Model").Include("Model.Manufacturer").Include("FuelType").Where(x => x.ModelId == modelId).ToList();//.OrderBy(m => m.Model.Manufacturer).ThenBy(m => m.Description).ToList();
            }

        public List<ProductGroup> GetProductGroups;

    }
}
