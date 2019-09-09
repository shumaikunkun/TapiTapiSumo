using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static bool isAnyKeyDown;
    public static bool mode; // true -> ゲームスタート : false -> チュートリアル
    const int leftStickCoolTime = 10;
    int coolTime;

    void Start()
    {
        isAnyKeyDown = false;
        mode = true;
        coolTime = leftStickCoolTime;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            isAnyKeyDown = true;
        }

        if (!isAnyKeyDown)
        {
            return;
        }

        // ゲームスタートかチュートリアルの選択　---------- //
        if (Input.GetAxis("Circle") == 1)
        {
            LoadSelectedMode();
        }

        // チャタリング防止用
        if (coolTime != 0)
        {
            coolTime--;
            return;
        }

        float leftStick = Input.GetAxisRaw("Vertical");
        if (leftStick != 0)
        {
            mode = 0 < leftStick ? true : false;
            coolTime = leftStickCoolTime;
            Debug.Log(mode);
        }
    }

    void LoadSelectedMode()
    {
        if (mode)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}