### Unity-InterfaceReference
A serializable class that holds the reference to an interface.

## How To:
1) Inherit from the serializable abstract class with your custom class.
2) Drag 'n' Drop a GameObject with a Component of specified interface type <I> to the target.
  
## Notes:
Multiple Components: 
1) For multiple components with <I> implementation on same gameObject by defult only the first is retrived.
  To assign another component that is not the first you should open two inspectors https://photos.app.goo.gl/Pw8Hq1o3qnCGoica6 :
  with one locked on the object with the interface reference you can use the other to manually assign the appointed component

Code:
1) By code you can access to the interface by implicitly casting the class to <I> "(I)interfaceReference" or just type "interfaceReference.Interface".
