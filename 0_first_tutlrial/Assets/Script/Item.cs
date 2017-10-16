using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    //private AudioSource destorysound;
    private void Start()
    {
        //destorysound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
