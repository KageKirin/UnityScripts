import UnityEngine
 
 class AManager (MonoBehaviour) :
 """
 AManager is a singleton.
 To avoid having to manually link an instance to every class that needs it, it has a static property called
 instance, so other objects that need to access it can just call:
        AManager.instance.DoSomeThing()
 """
 
    # s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
    private static s_Instance as AManager
 
    #This defines a static instance property that attempts to find the manager object in the scene and
    # returns it to the caller.
    public static instance :
        get :
            if s_Instance == null :
                # This is where the magic happens.
                #  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance =  FindObjectOfType(AManager) 
                if s_Instance == null:
                    Debug.Log ("Could not locate an AManager object. \n" +
                                        "You have to have exactly one AManager in the scene.");
 
            return s_Instance
 
    # Ensure that the instance is destroyed when the game is stopped in the editor.
    def OnApplicationQuit() :
        s_Instance = null
 
    # Add the rest of the code here...
    def DoSomeThing() :
        Debug.Log("Doing something now", self)
        