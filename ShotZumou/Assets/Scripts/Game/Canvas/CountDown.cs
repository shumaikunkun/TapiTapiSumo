using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    Text countDown;

    void Awake()
    {
        countDown = GetComponent<Text>();
    }

    public void SetText(int i)
    {
        countDown.text = i.ToString();
    }

    public void SetEnabled(bool enable)
    {
        countDown.enabled = enable;
    }
}