// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Manufacturer
    /// </summary>
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
