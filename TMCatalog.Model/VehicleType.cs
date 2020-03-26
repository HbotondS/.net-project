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
  /// Vehicle type
  /// </summary>
  public class VehicleType 
  {
    [Key]
    public int Id { get; set; }

    public string Description { get; set; }

    public int ModelId { get; set; }

    public Model Model { get; set; }

    public int TecDocID { get; set; }

    public int ProductionYearFrom { get; set; }

    public int ProductionYearTo { get; set; }

    public int FuelTypeId { get; set; }

    public FuelType FuelType { get; set; }
  }
}
