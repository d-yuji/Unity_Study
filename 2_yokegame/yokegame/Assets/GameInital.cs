using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInital : MonoBehaviour {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(800, 450, false, 60);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
