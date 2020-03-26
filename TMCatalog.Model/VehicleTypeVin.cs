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
  /// Vechicle type vin relation
  /// </summary>
  public class VehicleTypeVin
  {
    [Key]
    public string VIN { get; set; }

    public int VehicleTypeId { get; set; }

    public VehicleType VehicleType { get; set; }
  }
}
