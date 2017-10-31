using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKsystems.CodingExercise.Console.Domain.Enums
{
    /// <summary>
    /// Enumeration for product origin
    /// </summary>
    public enum EProductOrigin
    {
        [Description(" ")]
        MadeWithinOriginCountry = 1,

        [Description("Imported ")]
        Imported = 2,

        [Description("Assembled ")]
        Assembled = 3
    }
}
