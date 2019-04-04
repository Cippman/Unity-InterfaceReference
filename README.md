### Unity-InterfaceReference
A serializable class that holds the reference to an UnityEngine.Object that implements an interface T.

## How To:
1) Inherit from the serializable abstract class with your custom class.
2) Drag 'n' Drop a GameObject with a Component of specified interface type T to the target.
  
##  Notes:
Multiple Components: 
1) For multiple components with T implementation on same gameObject by defult only the first is retrived.
  To assign another component that is not the first you should open two inspectors https://photos.app.goo.gl/Pw8Hq1o3qnCGoica6 :
  with one locked on the object with the interface reference you can use the other to manually assign the appointed component

Code:
1) By code you can access to the interface by implicitly casting the class to T "(I)interfaceReference" or just type "interfaceReference.Interface".

## History: 
Inspired by ( https://assetstore.unity.com/packages/tools/iunified-12117 / https://forum.unity.com/threads/released-iunified-c-interfaces-for-unity.206988/ ) (an useful asset that I bought years ago) I'd like to give my solution to the question of how to serialize interfaces holded by components (or other objects)? What was the best plug 'n' play workflow/compromises to do this?

This version is completely free and different (as implementation). Just one script to do what I needed.

## Support:
(if you'd like to) Patreon: https://www.patreon.com/AlessandroSalani



### Roadmap (unsorted):
- some examples
- can I do this with a property attribute and an object?
- a forum thread?
