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
            o.Traits().Add<SomeTrait>(trait);
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
            o.Traits().Add<SomeTrait>(trait);
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
            var retreivedTrait = o.Traits().As<SomeInterface>();
            //then the object is returned
            Assert.True(object.ReferenceEquals(o, retreivedTrait));
        }

        [Test]
        public void CanCheckForImplementedInterfaces()
        {
            //given an object implements an interface
            var o = new SomeObject();
            //when AsTrait is called
            bool isTrait = o.Traits().Is<SomeInterface>();
            //then the object is returned
            Assert.True(isTrait);
        }

        [Test]
        public void CanCheckForATrait()
        {
            //given an object implements an interface
            var o = new SomeObject();
            o.Traits().Add<SomeTrait>(new SomeTrait());
            //when AsTrait is called
            bool isTrait = o.Traits().Has<SomeTrait>();
            //then the object is returned
            Assert.True(isTrait);
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

    }
}