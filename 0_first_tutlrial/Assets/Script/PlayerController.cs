using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float playerspeed = 10;
    private void FixedUpdate()
    {
        float pX = Input.GetAxis("Horizontal");
        float pZ = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(pX*playerspeed, 0, pZ*playerspeed);
    }
}
