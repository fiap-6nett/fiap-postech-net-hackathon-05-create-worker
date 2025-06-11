using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Worker.Domain.Enums;

public enum DeliveryType
{
    [Display(Name = "DineIn")]
    DineIn = 0,

    [Display(Name = "Delivery")]
    Delivery = 1,

    [Display(Name = "Drive-thru")]
    DriveThru = 2,

    [Display(Name = "PickupAtTable")]
    PickupAtTable = 3
}