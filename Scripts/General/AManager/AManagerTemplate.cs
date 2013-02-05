using UnityEngine;
using System.Collections;

public class AManagerTemplate<T> : MonoBehaviour where T: class
{
	private static T s_Instance = null;
	public static T instance
	{
		get
		{
			if (s_Instance == null)
			{
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManagerTemplate<T> object in the scene.
				s_Instance =  FindObjectOfType(typeof (T)) as T;
			}
 
			// If it is still null, create a new instance
			if (s_Instance == null)
			{
				GameObject obj = new GameObject(typeof(T).ToString());
				s_Instance = obj.AddComponent(typeof (T)) as T;
				Debug.Log("Could not locate an AManager object. AManagerTemplate<T> was Generated Automaticly.");
			}
 
			return s_Instance;
        }
	}
	public static T GetInstance()
	{
		return instance;
	}

	void OnApplicationQuit()
	{
		s_Instance = null;
	}
}
