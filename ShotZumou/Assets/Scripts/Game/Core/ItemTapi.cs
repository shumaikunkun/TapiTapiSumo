using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTapi : MonoBehaviour
{
    TapiState[] tapiState = new TapiState[2];

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            tapiState[i] = GameObject.Find("Camera" + (i + 1).ToString()).GetComponent<TapiState>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Object1" || tag == "Object2")
        {
            GameObject tapicup = other.transform.parent.transform.parent.gameObject;
            if (gameObject.tag == "TapiMany")
            {
                tapicup.transform.localScale += Vector3.one * 0.5f;
            }
            else if (gameObject.tag == "GoldTapi")
            {
                int num = int.Parse(tag.Substring(tag.Length - 1, 1));
                tapiState[num - 1].AddGoldTapi();
            }

            // 自身のゲームオブジェクトを破棄
            Destroy(gameObject);
        }
    }
}