using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField] Text text_InputAnyKey;
    [SerializeField] GameObject parent_Mode;
    [SerializeField] RectTransform image_CursorPosition;
    [SerializeField] GameObject parent_Title;

    void Start()
    {
        parent_Mode.SetActive(false);
        parent_Title.SetActive(false);
    }

    void Update()
    {
        if (text_InputAnyKey.enabled)
        {
            if (Input.anyKeyDown)
            {
                text_InputAnyKey.enabled = false;
                TitleManager.mode = true;
                parent_Mode.SetActive(true);
                parent_Title.SetActive(true);
            }
        }
        else
        {
            Vector2 newPosition = image_CursorPosition.anchoredPosition;
            if (TitleManager.mode)
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
}