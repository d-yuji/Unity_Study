using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    //public bool DontDestoryEnabled = true;
    static SoundManager _instance = null;
    static SoundManager instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<SoundManager>()); }
    }
    void Awake()
    {
        if (this != instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void OnDestroy()
    {
        if (this == instance) _instance = null;
    }

}
