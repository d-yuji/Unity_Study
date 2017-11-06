using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour {
    public GameObject player;
    public GameObject score;
    public GameObject title;

    public GameObject[] Blocks = new GameObject[5];
    private float createY = 3.5f;
    private float[] createX = new float[] {-3.5f,-2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, };


	// Use this for initialization
	void Start () {
        title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {
		if(IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
	}
    void GameStart()
    {
        title.SetActive(false);
        int rand = Random.Range(0, 7);
        int randB = Random.Range(0, 4);
        Instantiate(player, player.transform.position, player.transform.rotation);
        Instantiate(Blocks[randB], new Vector3(createX[rand],createY,0), Blocks[randB].transform.rotation);
    }
    public void GameOver()
    {

    }

    private IEnumerator DelayMethond(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }
}
