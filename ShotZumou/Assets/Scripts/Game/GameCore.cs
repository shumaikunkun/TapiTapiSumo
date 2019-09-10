using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static bool isEnd;
    const int Time = 5;
    public static float timer;

    // 終了後の行動選択用変数
    public static bool mode; // true -> ゲームスタート : false -> チュートリアル
    const int CoolTime = 10; // モード選択時に次の入力受け付けるまでのクールタイム
    int coolTimeForChoose;

    [SerializeField] GameObject gameCamera;
    [SerializeField] GameObject resultUI;

    void Awake()
    {
        isEnd = false;
        timer = Time;

        mode = true;
        coolTimeForChoose = CoolTime;
    }

    void Start()
    {
        gameCamera.SetActive(true);
        resultUI.SetActive(false);

        StartCoroutine("StartTimer");
    }

    void Update()
    {
        // プレイヤーが落ちたかどうかの処理

        // 勝敗決定後
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("StartTimer");
            GameEnd(1);
        }

        if (isEnd)
        {
            // ゲームスタートかチュートリアルの選択　---------- //
            if (Input.GetAxis("Circle") == 1)
            {
                LoadSelectedMode();
            }

            // チャタリング防止用
            if (coolTimeForChoose != 0)
            {
                coolTimeForChoose--;
                return;
            }

            float leftStick = Input.GetAxisRaw("Vertical");
            if (leftStick != 0)
            {
                mode = 0 < leftStick ? true : false;
                coolTimeForChoose = CoolTime;
            }
        }
    }

    void GameEnd(int winner)
    {
        gameCamera.SetActive(false);
        resultUI.SetActive(true);

        isEnd = true;
    }

    void LoadSelectedMode()
    {
        if (mode)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
    }

    IEnumerator StartTimer()
    {
        for (int i = 3; 0 <= i; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }

        for (; 0 < timer; timer--)
        {
            Debug.Log(timer);
            yield return new WaitForSeconds(1);
        }

        StartCoroutine("SuddenDeath");
    }

    IEnumerator SuddenDeath()
    {
        Debug.Log("サドンデスでーす");
        yield return new WaitForSeconds(1);
    }
}