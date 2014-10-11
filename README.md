NTraits
=====

Portable library for attaching behaviours to objects at runtime using extension methods.

Installation:

> Install-Package NTraits


Attaching a trait

```
     someObject.Traits().Add<SomeTraitType>(someTrait); //the trait will be registered using the generic method type
``` 

Checking for trait
```
     bool hasTrait = someObject.Has<SomeTraitType>(); //returns true or false
``` 


Checking for a trait, or the instance if it implements the requested type 
```
     bool hasTrait = someObject.Has<SomeTraitType>(); 
``` 

Retreiving a trait, or the instance if it implements the requested type 
```
     SomeTraitType trait = someObject.As<SomeTraitType>(); //will return null, or an instance of SomeTraitType
``` 

You can also cast back to any other trait on the traited entity, or back to the entity from a trait
```
     SomeTraitType trait = someObject.As<SomeTraitType>(); 
     
     SomeOtherTraitType otherTrait = trait.As<SomeOtherTraitType>(); 
     
     var originalSomeObject = otherTrait.As<SomeObject>(); 
     
``` 

Retreiving all traits attached to an object
```
     IEnumerable<object> traits = someObject.Traits(); //enumerable
``` 

Removing a trait
```
     bool removed = someObject.Traits().Pop<SomeTraitType>(); 
``` 





