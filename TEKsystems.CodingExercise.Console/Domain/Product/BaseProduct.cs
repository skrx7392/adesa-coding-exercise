
using System;
using TEKsystems.CodingExercise.Console.Domain.Enums;

namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Base class for all products.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.BaseDomain" />
    public abstract class BaseProduct : BaseDomain
	{
		public string Name { get; set; }
		
		public decimal Price { get; set; }
		
        public EProductOrigin ProductOrigin { get; set; }

	    public virtual ETaxStatus TaxStatus => ETaxStatus.Taxable;

        public virtual decimal TaxRate => .1m;
	}
}
