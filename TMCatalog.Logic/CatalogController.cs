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

        public List<Product> GetProducts(int vehicleTypeID)
        {
            return this.catalogDatabase.VehicleTypeProducts.Where(vt => vt.VehicleTypeId == vehicleTypeID).Select(p => p.Product).ToList();
        }

        public List<ProductGroup> GetProductGroups(int vehicleTypeID)
        {
            IEnumerable<VehicleTypeProducts> products = this.catalogDatabase.VehicleTypeProducts.Include("Product").Include("Product.ProductGroup").Where(vt => vt.VehicleTypeId == vehicleTypeID);
            List<ProductGroup> productGroups = new List<ProductGroup>();
            if (products.Count() > 0)
            {
                foreach (IGrouping<ProductGroup, VehicleTypeProducts> item in products.GroupBy(p => p.Product.ProductGroup))
                {
                    ProductGroup productGroup = item.Key;
                    productGroup.Products = new List<Product>();
                    foreach (VehicleTypeProducts product in item)
                    {
                        productGroup.Products.Add(product.Product);
                    }
                    productGroups.Add(productGroup);
                }
            }
            return productGroups;
        }

        public List<Article> GetArticles(int productID)
        {
            return this.catalogDatabase.Articles.Where(x => x.ProductId == productID).ToList() ?? new List<Article>();
        }

        public Stock GetArticleStock(int articleID)
        {
            return this.catalogDatabase.Stocks.FirstOrDefault(x => x.ArticleId == articleID);
        }
    }
}
