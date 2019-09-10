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
            Vector2 newPosition = image_CursorPosition.anchoredPosition;
            if (GameCore.mode)
            {
                newPosition.y = 50;
            }
            else
            {
                newPosition.y = -50;
            }
            image_CursorPosition.anchoredPosition = newPosition;
        }
    }

    public void SetWinnerText(int winner)
    {
        switch (winner)
        {
            case 0:
                winnerText.text = "Draw ;)";
                break;
            case 1:
                winnerText.text = "Win Player1 !";
                winnerText.color = Color.green;
                break;
            case 2:
                winnerText.text = "Win Player2 !";
                winnerText.color = Color.red;
                break;
            default:
                break;
        }
    }
}