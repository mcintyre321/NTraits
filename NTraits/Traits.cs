using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NTraits
{
    public class Traits : IEnumerable<object>
    {
        private readonly object _key;
        readonly Dictionary<Type, object> traits = new Dictionary<Type, object>();

        public Traits(object key)
        {
            _key = key;
        }



        public T Get<T>() where T : class
        {
            object value = null;
            if (traits.TryGetValue(typeof (T), out value))
            {
                return value as T;
            }
            return null;
        }
    
      
    
        public void Add<T>(T trait) where T:class
        {
            traits[typeof (T)] = trait;
            TraitsExtension.ents.Add(trait, _key);
        }

        public IEnumerator<object> GetEnumerator()
        {
            return traits.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        

        public bool Pop<T>()
        {
            return traits.Remove(typeof (T));
        }


    }
}