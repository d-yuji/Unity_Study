using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public bool DontDestoryEnabled = true;

	// Use this for initialization
	void Start () {
        if (DontDestoryEnabled)
        {
            DontDestroyOnLoad(this);
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
