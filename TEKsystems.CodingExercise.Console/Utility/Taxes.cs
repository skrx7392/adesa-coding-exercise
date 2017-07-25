using System;
using System.Collections.Generic;

using TEKsystems.CodingExercise.Console.Domain.Product;

namespace TEKsystems.CodingExercise.Console.Utility
{
	public static class Taxes
	{
		public static decimal ComputeSalesTax( List<BaseProduct> products )
		{
			decimal tax = 0;

			foreach( var product in products )
			{
				tax += ComputeSalesTax( product );
			}

			return tax;
		}

		public static decimal ComputeSalesTax( BaseProduct product )
		{
			decimal tax = 0;
			if( product.IsTaxable )
				tax += product.Price * product.TaxRate;

			if( product.IsImported )
				tax += (product.Price * .05m);

			return RoundingToNearest05Rule( tax );
		}

		public static decimal RoundingRule( decimal tax )
		{
			return Math.Round( tax, 2, MidpointRounding.AwayFromZero );
		}

		public static decimal RoundingToNearest05Rule( decimal tax )
		{
			var ceiling = Math.Ceiling( tax * 20 );
			if( ceiling == 0 )
			{
				return 0;
			}
			return ceiling / 20;
		}
	}
}
