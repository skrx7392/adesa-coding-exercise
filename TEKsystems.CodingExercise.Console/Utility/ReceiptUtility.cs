using System;
using System.Linq;
using System.Text;

using TEKsystems.CodingExercise.Console.Domain;
using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Helpers;
using TEKsystems.CodingExercise.Console.Interfaces;

namespace TEKsystems.CodingExercise.Console.Utility
{
	public class ReceiptUtility : IReceiptUtility
	{
        private readonly ITaxesUtility TaxesUtility;
		public ReceiptUtility(ITaxesUtility taxesUtility)
		{
            this.TaxesUtility = taxesUtility;
        }
        
        /// <summary>
        /// Creates a new receipt for all the items in a cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
		public string Create( Cart cart )
		{
			StringBuilder receipt = new StringBuilder();
			decimal totalTax = 0;

			foreach( var product in cart.Products )
			{
                var price = CalculateFinalPrice(product, out var tax);
				totalTax += tax;
				price = product.Price + tax;
				receipt.Append( "1 " );

                receipt.Append(StaticHelperMethods.GetEnumDescription(product.ProductOrigin, 0).ToLower());
                
				receipt.Append( product.Name + ": " + TaxesUtility.RoundingRule( price ) + Environment.NewLine );
			}

			decimal total = TaxesUtility.RoundingRule( cart.Products.Sum( p => p.Price ) + totalTax );

			receipt.Append( "Sales Taxes: " + TaxesUtility.RoundingRule( totalTax ).ToString( "0.00" ) + Environment.NewLine );
			receipt.Append( "Total: " + total.ToString() );

			return receipt.ToString();
		}

        /// <summary>
        /// Gives out price after tax and tax of each product. 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        private decimal CalculateFinalPrice(BaseProduct product, out decimal tax)
        {
            tax = TaxesUtility.ComputeSalesTax(product);
            return product.Price + tax;
        }
	}
}
