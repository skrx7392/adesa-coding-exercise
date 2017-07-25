using System;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Medical product.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.Product.BaseProduct" />
    public class Medical : BaseProduct
    {
        public override bool IsTaxable => false;
    }
}
