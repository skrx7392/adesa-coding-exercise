using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKsystems.CodingExercise.Console.Domain.Product;

namespace TEKsystems.CodingExercise.Console.Interfaces
{
    public interface ITaxesUtility
    {
        decimal ComputeSalesTax(List<BaseProduct> products);
        decimal ComputeSalesTax(BaseProduct product);
        decimal RoundingRule(decimal tax);
        decimal RoundingToNearest05Rule(decimal tax);
    }
}
