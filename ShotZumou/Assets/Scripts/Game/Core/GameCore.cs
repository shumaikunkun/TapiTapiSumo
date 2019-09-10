using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static bool isStart;
    public static bool isEnd;
    const int Time = 5;
    public static int timer;

    // 終了後の行動選択用変数
    public static bool mode; // true -> ゲームスタート : false -> チュートリアル
    const int CoolTime = 10; // モード選択時に次の入力受け付けるまでのクールタイム
    int coolTimeForChoose;

    [SerializeField] GameObject minimapCamera;
    [SerializeField] GameObject[] playerCamera = new GameObject[2];
    [SerializeField] GameObject resultUI;
    GameObject[] target = new GameObject[2];
    GameResultCanvas resultCanvas;
    CountDown countDown;
    OnGameText onGameText;

    void Awake()
    {
        isStart = false;
        isEnd = false;
        timer = Time;

        mode = true;
        coolTimeForChoose = CoolTime;

        target[0] = GameObject.FindGameObjectWithTag("Object1");
        target[1] = GameObject.FindGameObjectWithTag("Object2");
        resultCanvas = GameObject.Find("Result").GetComponent<GameResultCanvas>();
        countDown = GameObject.Find("CountDown").GetComponent<CountDown>();
        onGameText = GameObject.Find("OnGame").GetComponent<OnGameText>();
        onGameText.SetEnabled(false);
    }

    void Start()
    {
        minimapCamera.SetActive(true);
        foreach (var camera in playerCamera)
        {
            camera.SetActive(true);
        }
        resultUI.SetActive(false);

        StartCoroutine("StartTimer");
    }

    void Update()
    {
        // 勝敗判定
        float player1Y = target[0].transform.position.y;
        float player2Y = target[1].transform.position.y;
        if (player1Y < -1 || player2Y < -1)
        {
            int winner = 0; // 0:引き分け 1:Player1の勝利 2:Player2の勝利
            if (player1Y < -1 && -1 <= player2Y)
            {
                winner = 2;
            }
            else if (-1 <= player1Y && player2Y < -1)
            {
                winner = 1;
            }

            GameEnd(winner);
        }

        // 終了したらの処理
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
        minimapCamera.SetActive(false);
        onGameText.SetEnabled(false);
        foreach (var camera in playerCamera)
        {
            camera.SetActive(false);
        }
        resultUI.SetActive(true);
        resultCanvas.SetWinnerText(winner);

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
        for (int i = 3; 0 < i; i--)
        {
            countDown.SetText(i);
            yield return new WaitForSeconds(1);
        }

        countDown.SetEnabled(false);
        isStart = true;
        onGameText.SetEnabled(true);

        for (; 0 < timer; timer--)
        {
            onGameText.SetTimerText(timer);
            yield return new WaitForSeconds(1);
        }

        StartCoroutine("SuddenDeath");
    }

    IEnumerator SuddenDeath()
    {
        onGameText.SetTimerText(-1);
        yield return new WaitForSeconds(1);
    }
}