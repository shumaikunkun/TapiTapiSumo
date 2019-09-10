using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameText : MonoBehaviour
{
    Text timerText;

    void Awake()
    {
        timerText = transform.Find("Timer").GetComponent<Text>();
    }

    public void SetTimerText(int time)
    {
        if (time == -1)
        {
            timerText.text = "サドンデス";
        }
        else
        {
            timerText.text = time.ToString();
        }
    }

    public void SetEnabled(bool enable)
    {
        gameObject.SetActive(enable);
    }
}