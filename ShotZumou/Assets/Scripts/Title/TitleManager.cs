using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static bool isAnyKeyDown; // 最初のInput Any Key が押されたか否か
    public static bool mode; // true -> ゲームスタート : false -> チュートリアル
    const int CoolTime = 10; // モード選択時に次の入力受け付けるまでのクールタイム
    int coolTimeForChoose;
    bool isCircleKeyDown;

    void Awake()
    {
        isAnyKeyDown = false;
        mode = true;
        coolTimeForChoose = CoolTime;
        isCircleKeyDown = false;
    }

    void Update()
    {
        float circle = Input.GetAxisRaw("Circle");

        // InputAnyKey用
        if (!isAnyKeyDown)
        {
            if (Input.anyKeyDown)
            {
                if (circle == 1)
                {
                    isCircleKeyDown = true;
                }
                isAnyKeyDown = true;
            }
            return;
        }

        // InputAnyKeyのときに丸が押されたとき用にGetKeyDownと同じものをAxisに作った
        if (circle == 1)
        {
            if (!isCircleKeyDown)
            {
                // ゲームスタートかチュートリアルの選択　---------- //
                LoadSelectedMode();

                isCircleKeyDown = true;
            }
        }
        if (circle == 0)
        {
            isCircleKeyDown = false;
        }

        // チャタリング防止用
        if (coolTimeForChoose != 0)
        {
            coolTimeForChoose--;
            return;
        }

        // モード選択
        float leftStick = Input.GetAxisRaw("Vertical");
        if (leftStick != 0)
        {
            mode = 0 < leftStick ? true : false;
            coolTimeForChoose = CoolTime;
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