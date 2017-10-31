using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKsystems.CodingExercise.Console.Helpers
{
    /// <summary>
    /// Contains static methods which can be used globally
    /// </summary>
    public static class StaticHelperMethods
    {
        /// <summary>
        /// Get string description of a particular enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(T e, int descriptionNumber) where T : IConvertible
        {
            if(e is Enum)
            {
                var type = e.GetType();
                var values = System.Enum.GetValues(type);
                foreach(int val in values)
                {
                    if(val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Any())
                        {
                            return ((DescriptionAttribute)descriptionAttributes[descriptionNumber]).Description;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
