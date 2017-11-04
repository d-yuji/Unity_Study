using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private float time = 150;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ((int)time).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time < 0)
        {
            FindObjectOfType<Player>().TimeOver();
            Destroy(gameObject);
        }
        GetComponent<Text>().text = ((int)time).ToString();
    }
}
