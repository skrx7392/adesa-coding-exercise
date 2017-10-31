using System;
using System.Collections.Generic;
using TEKsystems.CodingExercise.Console.Domain.Enums;
using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Interfaces;

namespace TEKsystems.CodingExercise.Console.Utility
{
	public class TaxesUtility : ITaxesUtility
	{
		public decimal ComputeSalesTax( List<BaseProduct> products )
		{
			decimal tax = 0;

			foreach( var product in products )
			{
				tax += ComputeSalesTax( product );
			}

			return tax;
		}

		public decimal ComputeSalesTax( BaseProduct product )
		{
			decimal tax = 0;
            tax += CalculateTaxBasedOnExemption(product);
            tax += CalculateTaxBasedOnOrigin(product);
			
			return RoundingToNearest05Rule( tax );
		}

		public decimal RoundingRule( decimal tax )
		{
			return Math.Round( tax, 2, MidpointRounding.AwayFromZero );
		}

		public decimal RoundingToNearest05Rule( decimal tax )
		{
			var ceiling = Math.Ceiling( tax * 20 );
			if( ceiling == 0 )
			{
				return 0;
			}
			return ceiling / 20;
		}

        /// <summary>
        /// Used to calculate tax based on Origin only. Two ways to extend this method further: 
        /// 1. Continue adding new conditions to switch statements
        /// 2. Store the values in database and get them directly when needed. 
        /// (This removes the need for rebuilding the codebase whenever there's any new status, as it can be done through sql script deployment.)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private decimal CalculateTaxBasedOnOrigin(BaseProduct product)
        {
            decimal tax;
            switch(product.ProductOrigin)
            {
                case EProductOrigin.Imported:
                    tax = product.Price * .05m;
                    break;
                default:
                    tax = 0;
                    break;
            }
            return tax;
        }

        /// <summary>
        /// Used to calculate tax based on Tax Status only. 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private decimal CalculateTaxBasedOnExemption(BaseProduct product)
        {
            decimal tax;
            switch (product.TaxStatus)
            {
                case ETaxStatus.Taxable:
                    tax = product.Price * product.TaxRate;
                    break;
                default:
                    tax = 0;
                    break;
            }
            return tax;
        }

	}
}
