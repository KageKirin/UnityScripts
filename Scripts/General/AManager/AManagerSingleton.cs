using UnityEngine;
using System;


public abstract class AManagerSingleton<T> : MonoBehaviour where T: class
{		
	static public T Instance
	{
		get
		{
			return SingletonInternal.instance;
		}

		private set
		{
			SingletonInternal.instance = value;
		}
	}
	static public T GetInstance()
	{
		return Instance;
	}

	private class SingletonInternal
	{
		static SingletonInternal()
		{
		}

		static T FindOrCreateInstance()
		{
			T inst = FindObjectOfType(typeof(T)) as T;
			if (inst == null)
			{
				GameObject obj = new GameObject(typeof(T).ToString());
				inst = obj.AddComponent(typeof(T)) as T;
				Debug.Log("could not locate object of type " + typeof(T).ToString() + " therefore created one");
			}
			return inst;
		}

		internal static T instance = FindOrCreateInstance();
	};

	void OnApplicationQuit()
	{
		Instance = null;
	}
};
