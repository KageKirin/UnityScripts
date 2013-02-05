 /// AManager is a singleton.
 /// To avoid having to manually link an instance to every class that needs it, it has a static variable called
 /// instance, so other objects that need to access it can just call:
 ///        AManager.instance.DoSomeThing();
 ///
 static var instance : AManager;
 
 // This is where the magic happens.
 //  FindObjectOfType(...) returns the first AManager object in the scene.
 instance =  FindObjectOfType(AManager);
 if (instance == null)
     Debug.Log ("Could not locate an AManager object. \n" +
                     "You have to have exactly one AManager in the scene.");
 
 // Ensure that the instance is destroyed when the game is stopped in the editor.
 function OnApplicationQuit() {
     instance = null;
 }
 
 // Add the rest of the code here...
 
 function DoSomeThing() {
     Debug.Log("Doing something now", this);
 }
 