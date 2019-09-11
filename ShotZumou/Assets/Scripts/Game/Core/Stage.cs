using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if ("サドンデスタイム")
        //{
        //Debug.Log(transform.localScale.x);
        //Debug.Log(transform.lossyScale.x);
        transform.localScale -= new Vector3(0.01f, 0, 0.01f);
        //時間とともにフィールドが縮小

        //Debug.Log(GameObject.FindWithTag("Player").transform.position.z);
        GameObject.FindWithTag("Player1").transform.localPosition += new Vector3(0, 0, 0.005f);
        //GameObject.FindWithTag("Player2").transform.localPosition += new Vector3(0, 0, 0.005f);
        //マルチプレイ時上のスクリプトをコメントアウト解除する

        //}
    }
}