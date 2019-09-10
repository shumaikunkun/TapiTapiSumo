using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultCanvas : MonoBehaviour
{
    [SerializeField] RectTransform image_CursorPosition;
    [SerializeField] Text winnerText;

    void Start()
    {

    }

    void Update()
    {
        if (GameCore.isEnd)
        {
            if (GameCore.mode)
            {
                image_CursorPosition.anchoredPosition = new Vector3(0, 50, 0);
            }
            else
            {
                image_CursorPosition.anchoredPosition = new Vector3(0, -50, 0);
            }
        }
    }

    public void SetWinnerText(int winner)
    {
        switch (winner)
        {
            case 0:
                winnerText.text = "引き分け";
                break;
            case 1:
                winnerText.text = "Player1の勝利";
                break;
            case 2:
                winnerText.text = "Player2の勝利";
                break;
            default:
                break;
        }
    }
}