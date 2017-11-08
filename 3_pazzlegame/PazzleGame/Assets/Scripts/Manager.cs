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

    public float timeOut;
    private float timeElapsed = 0;

    public GameObject[,] blockArrays = new GameObject[9,9];

    // Use this for initialization
    void Start () {
        title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {

        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
        else if(IsPlaying())
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeOut)
            {
                int rand = Random.Range(0, 7);
                int randB = Random.Range(0, 4);
                GameObject block = Instantiate(Blocks[randB], new Vector3(createX[rand], createY, 0), Blocks[randB].transform.rotation);
                int temp;
                for (int i = 7; i >= 0; i--)
                {
                    temp = i;
                    if (blockArrays[rand, temp] == null)
                    {
                        blockArrays[rand, temp] = block;
                        Vector2 tempVec = block.transform.position;
                        tempVec.y = 3.5f - i;
                        block.transform.position = tempVec;
                        break;
                    }
                }
                timeElapsed = 0.0f;
            }
        }
	}
    void GameStart()
    {
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }
    public void GameOver()
    {
        return;
    }

    private IEnumerator DelayMethond(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }

    public bool isBlock(int bx,int by)
    {
        if(blockArrays[bx,by] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
