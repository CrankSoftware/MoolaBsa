using System.Collections.Generic;
using System.Linq;

namespace Moola.Bsa.Logic.ExtensionMethods
{
    public static class ExtendIEnumerable
    {
        public static bool AnySave(this IEnumerable<object> objects)
        {
            return objects!=null && objects.Any();
        }
    }
}
