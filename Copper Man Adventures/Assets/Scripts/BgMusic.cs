using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public static BgMusic instance;

    private void awake()
    {
	if(instance == null)
	{
	   DontDestroyOnLoad(this.gameObject);
	   instance = this;
	}
	else
	{
	  Destroy(gameObject); 
	}
    }
}
