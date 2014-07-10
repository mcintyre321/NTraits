using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NTraits
{
    public static class TraitsExtension
    {
        private static readonly ConditionalWeakTable<object, Traits> props = new ConditionalWeakTable<object, Traits>();
        public static Traits Traits(this object key)
        {
            return props.GetValue(key, o => new Traits(o));
        }
    }
}