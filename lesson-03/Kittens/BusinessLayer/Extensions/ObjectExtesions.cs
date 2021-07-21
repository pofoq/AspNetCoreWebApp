using System;

namespace BusinessLayer.Extensions
{
    public static class ObjectExtesions
    {
        public static void EnsureNotNull(this object @object, string name)
        {
            if (@object is null)
            {
                throw new ArgumentNullException(name, $"Parameter {name} cannot be null.");
            }
        }
    }
}
