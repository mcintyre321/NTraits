using System;

namespace NTraits
{
    public static class WithTraitExtension
    {
        public static T With<T, TTrait>(this T e, TTrait t) where TTrait : class
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