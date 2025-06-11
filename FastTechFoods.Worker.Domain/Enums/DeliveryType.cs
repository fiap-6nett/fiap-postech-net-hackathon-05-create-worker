using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Worker.Domain.Enums
{
    public enum DeliveryType
    {
        [Display(Name = "Counter")]
        Counter = 0,

        [Display(Name = "Drive-thru")]
        Delivery = 1,

        [Display(Name = "Delivery")] 
        DriveThru = 2
    }
}