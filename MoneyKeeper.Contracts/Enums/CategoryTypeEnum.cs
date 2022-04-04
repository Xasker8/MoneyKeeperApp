using System.ComponentModel.DataAnnotations;

namespace MoneyKeeper.Contracts.Enums
{
    public enum CategoryTypeEnum
    {
        [Display(Name = "Service")]
        Service = 0,

        [Display(Name = "Income")]
        Income = 1,

        [Display(Name = "Expence")]
        Expence = 2
    }
}
