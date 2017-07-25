using System;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Food product.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.Product.BaseProduct" />
    public class Food : BaseProduct
    {
        public override bool IsTaxable => false;
    }
}
