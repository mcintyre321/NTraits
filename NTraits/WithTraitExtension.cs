using System;

namespace NTraits
{
    public static class WithTraitExtension
    {
        public static object With<T>(this object e) where T : class, new()
        {
            e.Traits().Add(new T());
            return e;
        }
        public static object With<T>(this object e, T t) where T : class
        {
            e.Traits().Add(t);
            return e;
        }

        public static T With<T, TTrait>(this T e, Func<T, TTrait> create)
            where T : class
            where TTrait : class
        {
            e.Traits().Add(create(e));
            return e;
        }

 

    }
}