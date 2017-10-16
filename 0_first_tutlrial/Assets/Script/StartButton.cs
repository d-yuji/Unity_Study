using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public AudioSource startsound;
	void Start () {
        startsound = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
    void OnClick()
    {
        SceneManager.LoadScene("Stage01");
    }	
}
