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
     bool hasTrait = someObject.Traits().Has<SomeTraitType>(); //returns true or false
``` 

Retreiving a trait
```
     SomeTraitType trait = someObject.Traits().Get<SomeTraitType>(); //will return null if there is no trait of type SomeTraitType
``` 

Checking for a trait, or the instance if it implements the requested type 
```
     bool hasTrait = someObject.Traits().Is<SomeTraitType>(); //will return null, or an instance of SomeTraitType
``` 

Retreiving a trait, or the instance if it implements the requested type 
```
     SomeTraitType trait = someObject.Traits().As<SomeTraitType>(); //will return null, or an instance of SomeTraitType
``` 

Retreiving all traits attached to an object
```
     IEnumerable<object> traits = someObject.Traits(); //enumerable
``` 

Removing a trait
```
     bool removed = someObject.Traits().Pop<SomeTraitType>(); 
``` 





