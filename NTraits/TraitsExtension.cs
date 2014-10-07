using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NTraits
{
    public static class TraitsExtension
    {
        private static readonly ConditionalWeakTable<object, Traits> props = new ConditionalWeakTable<object, Traits>();
        internal static readonly ConditionalWeakTable<object, object> ents = new ConditionalWeakTable<object, object>();
        public static Traits Traits(this object key)
        {
            return props.GetValue(key, o => new Traits(o));
        }

        public static object Entity(this object trait)
        {
            return ents.GetValue(trait, key => null);
        }

        public static T As<T>(this object o) where T : class
        {
            var ent = o.Entity();
            if (ent != null)
            {
                return ent.As<T>();
            }
            else
            {
                return o as T ?? o.Traits().Get<T>();
            }
        }

        public static bool Has<T>(this object o) where T : class
        {
            return o.As<T>() != null;
        }
    }
}