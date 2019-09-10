using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultCanvas : MonoBehaviour
{
    [SerializeField] RectTransform image_CursorPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
}