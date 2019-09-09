using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField] Text text_InputAnyKey;
    [SerializeField] GameObject parent_Mode;
    [SerializeField] RectTransform image_CursorPosition;

    void Start()
    {
        parent_Mode.SetActive(false);
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
            }
        }
        else
        {
            if (TitleManager.mode)
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