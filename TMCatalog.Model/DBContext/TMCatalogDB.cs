// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.Model.DBContext
{
    using System.Data.Entity;
    using TMCatalogClient.Model;

    /// <summary>
    /// TM catalog data base context
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class TMCatalogDB : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TMCatalogDB"/> class.
        /// </summary>
        public TMCatalogDB()
          : base("name=TMCatalogDB")
        {
        }

        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        /// <value>
        /// The articles.
        /// </value>
        public virtual DbSet<Article> Articles { get; set; }

        /// <summary>
        /// Gets or sets the fuel types.
        /// </summary>
        /// <value>
        /// The fuel types.
        /// </value>
        public virtual DbSet<FuelType> FuelTypes { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the models.
        /// </summary>
        /// <value>
        /// The models.
        /// </value>
        public virtual DbSet<Model> Models { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the product groups.
        /// </summary>
        /// <value>
        /// The product groups.
        /// </value>
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }

        /// <summary>
        /// Gets or sets the stocks.
        /// </summary>
        /// <value>
        /// The stocks.
        /// </value>
        public virtual DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Gets or sets the vehicle types.
        /// </summary>
        /// <value>
        /// The vehicle types.
        /// </value>
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type articles.
        /// </summary>
        /// <value>
        /// The vehicle type articles.
        /// </value>
        public virtual DbSet<VehicleTypeArticles> VehicleTypeArticles { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type plate NRS.
        /// </summary>
        /// <value>
        /// The vehicle type plate NRS.
        /// </value>
        public virtual DbSet<VehicleTypePlateNr> VehicleTypePlateNrs { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type products.
        /// </summary>
        /// <value>
        /// The vehicle type products.
        /// </value>
        public virtual DbSet<VehicleTypeProducts> VehicleTypeProducts { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type vin.
        /// </summary>
        /// <value>
        /// The vehicle type vin.
        /// </value>
        public virtual DbSet<VehicleTypeVin> VehicleTypeVin { get; set; }
    }
}