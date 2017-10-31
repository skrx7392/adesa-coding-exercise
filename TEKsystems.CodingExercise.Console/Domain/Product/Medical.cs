using System;
using TEKsystems.CodingExercise.Console.Domain.Enums;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Medical product.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.Product.BaseProduct" />
    public class Medical : BaseProduct
    {
        public override ETaxStatus TaxStatus => ETaxStatus.TaxExempt;
    }
}
