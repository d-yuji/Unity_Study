using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    public UnityEngine.UI.Text scoreLabel;
    public GameObject finishLabelObject;
    private float timeOut = 5.0f;
    private float timeTrigger;

    // Update is called once per frame
    void Update () {
        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreLabel.text = count.ToString();
        if (count == 0)
        {
            timeTrigger += Time.deltaTime;
            finishLabelObject.SetActive(true);
            if(timeTrigger >= timeOut)
            {
                timeTrigger = 0.0f;
                SceneManager.LoadScene("start");
            }
            
        }
	}
}
