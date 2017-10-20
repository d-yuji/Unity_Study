using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public AudioClip destorysound;
    private void Start()
    {
        //destorysound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(destorysound, transform.position);
            Destroy(gameObject);
        }
    }
}
