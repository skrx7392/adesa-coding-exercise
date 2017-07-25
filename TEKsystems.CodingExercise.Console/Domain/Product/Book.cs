using System;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Book product.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.Product.BaseProduct" />
    public class Book : BaseProduct
    {
        public override bool IsTaxable => false;
    }
}
