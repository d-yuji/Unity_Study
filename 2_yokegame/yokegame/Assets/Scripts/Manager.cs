using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject player;
    public GameObject timer;
    GameObject timerObject;
    // タイトル
    private GameObject title;

    void Start()
    {
        // Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find("TitleCanvas");
    }

    void Update()
    {
        // ゲーム中ではなく、Xキーが押されたらtrueを返す。
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
    }

    void GameStart()
    {
        // ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
        timerObject = Instantiate(timer) as GameObject;
    }

    public void GameOver()
    {
        // ゲームオーバー時に、タイトルを表示する
        title.SetActive(true);
        Vector3 cameraPos = new Vector3(0, 0, -10);
        Camera.main.transform.position = cameraPos;
        Destroy(timerObject.gameObject);
    }

    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        return title.activeSelf == false;
    }
}
