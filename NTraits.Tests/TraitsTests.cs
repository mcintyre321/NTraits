using NUnit.Framework;

namespace NTraits.Tests
{
    public class TraitsTests
    {
        [Test]
        public void NullWhenNoTrait()
        {
            //given no trait is attached to an object
            var o = new object();
            //when a trait is retreived
            var retreivedTrait = o.Traits().Get<SomeTrait>();
            //then null is returned
            Assert.IsNull(retreivedTrait);
        }

        [Test]
        public void CanAttachATrait()
        {
            //given a trait is attached to an object
            var o = new object();
            var trait = new SomeTrait();
            o.Traits().Add(trait);
            //when the trait is requested by type
            var retreivedTrait = o.Traits().Get<SomeTrait>();
            //then the trait is returned
            Assert.True(object.ReferenceEquals(trait, retreivedTrait));
        }

        [Test]
        public void CanRemoveATrait()
        {
            //given a trait is attached to an object
            var o = new object();
            var trait = new SomeTrait();
            o.Traits().Add(trait);
            //and the trait is removed
            bool wasRemoved = o.Traits().Pop<SomeTrait>();
            //when the trait is requested by type
            var retreivedTrait = o.Traits().Get<SomeTrait>();
            //then the trait is returned as null 
            Assert.Null(retreivedTrait);
            //and the return value is set correctly
            Assert.True(wasRemoved);
        }

        [Test]
        public void ReturnValueIsCorrectWhenPoppingAnUnattachedTraitType()
        {
            //given no trait is attached to an object
            var o = new object();
            //and the trait is removed
            bool wasRemoved = o.Traits().Pop<SomeTrait>();
            //and the return value is set correctly
            Assert.False(wasRemoved);
        }

        [Test]
        public void CanReturnImplementedInterfacesFromAs()
        {
            //given an object implements an interface
            var o = new SomeObject();
            //when AsTrait is called
            var retreivedTrait = o.As<SomeInterface>();
            //then the object is returned
            Assert.True(object.ReferenceEquals(o, retreivedTrait));
        }
        [Test]
        public void CanReturnTraitFromAs()
        {
            //given an object implements an interface
            var someTrait = new SomeTrait();
            var o = new SomeObject()
                .With(someTrait);
            //when AsTrait is called
            var retreivedTrait = o.As<SomeTrait>();
            //then the object is returned
            Assert.True(object.ReferenceEquals(someTrait, retreivedTrait));
        }
 
        [Test]
        public void CanCheckForATrait()
        {
            //given an object implements an interface
            var o = new SomeObject();
            o.With(new SomeTrait());
            //when AsTrait is called
            bool isTrait = o.Has<SomeTrait>();
            //then the object is returned
            Assert.True(isTrait);
        }

        [Test]
        public void CanGetParentFromATrait()
        {
            var o = new SomeObject();
            var someTrait = new SomeTrait();
            o.Traits().Add(someTrait);
            //when Entity() is called 
            var entity = someTrait.Entity();
            //then the paretn is returned
            Assert.AreEqual(o, entity);
        }


        [Test]
        public void CanGetOneTraitFromAnother()
        {
            var o = new SomeObject();
            var someTrait = new SomeTrait();
            o.Traits().Add(someTrait);
            var someTrait2 = new SomeTrait2();
            o.Traits().Add(someTrait2);

            //when .As is called on one trait
            var retreivedTrait = someTrait.As<SomeTrait2>();
            //then the other trait is returned
            Assert.AreEqual(someTrait2, retreivedTrait);
        }



        public interface SomeInterface
        {
        }

        public class SomeObject : SomeInterface
        {
        }

        public class SomeTrait
        {
        }
        public class SomeTrait2
        {
        }
    }

    
}