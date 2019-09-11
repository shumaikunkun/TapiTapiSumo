using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameText : MonoBehaviour
{
    [SerializeField] TapiState[] tapiStates = new TapiState[2];

    Text timerText;
    [SerializeField] Text[] goldText = new Text[2];

    void Awake()
    {
        timerText = transform.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            goldText[i].text = tapiStates[i].goldTapi.ToString();
        }
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