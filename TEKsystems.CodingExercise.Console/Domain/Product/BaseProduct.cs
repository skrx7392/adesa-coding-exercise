
using System;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Base class for all products.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.BaseDomain" />
    public abstract class BaseProduct : BaseDomain
	{
		public string Name { get; set; }
		
		public decimal Price { get; set; }
		
        public bool IsImported { get; set; }

	    public virtual bool IsTaxable => true;

        public virtual decimal TaxRate => .1m;
	}
}
