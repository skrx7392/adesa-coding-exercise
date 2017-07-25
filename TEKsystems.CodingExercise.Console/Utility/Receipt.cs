using System;
using System.Linq;
using System.Text;

using TEKsystems.CodingExercise.Console.Domain;

namespace TEKsystems.CodingExercise.Console.Utility
{
	public class Receipt
	{
		private Receipt()
		{}

		private static readonly Lazy<Receipt> _instance = new Lazy<Receipt>( () => new Receipt() );

		public static Receipt Instance
		{ get { return _instance.Value; } }

		public string Create( Cart cart )
		{
			StringBuilder receipt = new StringBuilder();
			decimal totalTax = 0;

			foreach( var product in cart.Products )
			{
				decimal tax = Taxes.ComputeSalesTax( product );
				totalTax += tax;
				decimal price = product.Price + tax;
				receipt.Append( "1 " );

				if( product.IsImported ) receipt.Append( "imported " );
				
				receipt.Append( product.Name + ": " + Taxes.RoundingRule( price ) + Environment.NewLine );
			}

			decimal total = Taxes.RoundingRule( cart.Products.Sum( p => p.Price ) + totalTax );

			receipt.Append( "Sales Taxes: " + Taxes.RoundingRule( totalTax ).ToString( "0.00" ) + Environment.NewLine );
			receipt.Append( "Total: " + total.ToString() );

			return receipt.ToString();
		}
	}
}
