using System;

using TEKsystems.CodingExercise.Console.Domain;
using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Utility;

namespace TEKsystems.CodingExercise.Console
{
	class Program
	{
        static void Main( string[] args )
		{
		    var cartId = 0;

            var cart1 = new Cart { Id = ++cartId };
		    cart1.Products.Add( new Book { Name = "book", Price = 12.49m, IsImported = false } );
			cart1.Products.Add( new Music { Name = "music CD", Price = 14.99m, IsImported = false } );
			cart1.Products.Add( new Food { Name = "chocolate bar", Price = 0.85m, IsImported = false } );

            var cart2 = new Cart { Id = ++cartId  };
		    cart2.Products.Add( new Food { Name = "box of chocolates", Price = 10.00m, IsImported = true } );
			cart2.Products.Add( new Perfume { Name = "bottle of perfume", Price = 47.50m, IsImported = true } );

            var cart3 = new Cart { Id = ++cartId  };
		    cart3.Products.Add( new Perfume { Name = "bottle of perfume", Price = 27.99m, IsImported = true } );
			cart3.Products.Add( new Perfume { Name = "bottle of perfume", Price = 18.99m, IsImported = false } );
			cart3.Products.Add( new Medical { Name = "packet of headache pills", Price = 9.75m, IsImported = false } );
			cart3.Products.Add( new Food { Name = "box of chocolates", Price = 11.25m, IsImported = true } );

            var carts = new [] { cart1, cart2, cart3 };
			foreach( var cart in carts )
			{
                System.Console.Out.WriteLine( "=================================================================================" );
				System.Console.Out.WriteLine( "Receipt " + cart.Id + ":" );
                System.Console.Out.WriteLine( "-------------------------------------------------" );
				System.Console.Out.WriteLine( Receipt.Instance.Create( cart ) );
				System.Console.Out.WriteLine();
			}

			System.Console.WriteLine( "Press ESC to quit ..." );
            do
            { while( !System.Console.KeyAvailable ) {} }
            while( System.Console.ReadKey(true).Key != ConsoleKey.Escape );
		}
	}
}
