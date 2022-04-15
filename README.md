# Unity-InterfaceReference
Create your custom serializable class that
holds the reference to an UnityEngine.Object 
that implements an interface I.

### Purpose: 
The main purpose of InterfaceReference is to present 
a code friendly solution to reference UnityEngine.Objects
with Interface I in Inspector.

### Contents:
The repository comes with main class InterfaceReference'I; 
support scripts and few attributes.

### How to Install:
- Option 1 (readonly) now it supports Unity Package Manager so you can download by copy/paste the git url in 'Package Manager Window + Install From Git'.
  As said this is a readonly solution so you cannot access all files this way.
- Option 2 (classic) download this repository as .zip; Extract the files; Drag 'n' drop the extracted folder in your unity project (where you prefer).
- Option 3 (alternative) add this as submodule / separate repo in your project
- Option 4 (vintage) use the old ".unitypackage"
  

###  Notes:
Multiple Components: 
- For multiple components with T implementation 
on same gameObject by defult only the first is 
retrived. To assign another component that is not 
the first you should open [two inspectors](https://photos.app.goo.gl/Pw8Hq1o3qnCGoica6):
with one locked on the object with the interface
reference you can use the other to manually assign
the appointed component

Code:
* The process to create your custom reference to your
interface is similar to create custom events 
with UnityEvents.
Just inherit from InterfaceReference'I with your custom
serializable class where I is the interface. 
  * By code you can access to the interface by implicitly
  casting the class to T "(I)interfaceReference" or just type "interfaceReference.Interface".
  (see also the examples)
- Alternatively you can declare a UnityEngine.Object and
use the TypeFilterAttribute (another solution). 
Then at runtime cast it to the interface

### History: 
Inspired by (IUnified [asset store](https://assetstore.unity.com/packages/tools/iunified-12117) 
and [forum](https://forum.unity.com/threads/released-iunified-c-interfaces-for-unity.206988/))
(an useful asset that I bought years ago) I'd like to put me on try
and present my solution to the question of how to 
serialize interfaces held by components (or other objects)?
What is the best plug 'n' play workflow/compromises to do this?

This version is completely free and different (as implementation).

### Links:
- [forum](https://forum.unity.com/threads/repository-interface-reference.672535/)
- [repo](https://github.com/Cippman/Unity-InterfaceReference.git)

### Support:
- [tip jar](https://www.amazon.it/photos/share/Gbg3FN0k6pjG6F5Ln3dqQEmwO0u4nSkNIButm3EGtit)
