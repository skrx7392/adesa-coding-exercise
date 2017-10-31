using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKsystems.CodingExercise.Console.Domain;

namespace TEKsystems.CodingExercise.Console.Interfaces
{
    public interface IReceiptUtility
    {
        string Create(Cart cart);
    }
}
