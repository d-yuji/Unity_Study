using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform targetPlayer;
    private Vector3 offset;
    private void Start()
    {
        offset = GetComponent<Transform>().position - targetPlayer.position;
    }
    void Update () {
        GetComponent<Transform>().position = targetPlayer.position + offset;
	}
}
