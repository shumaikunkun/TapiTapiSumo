﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTapi : MonoBehaviour
{

    void OnCollsionEnter(Collision other)
    {
        // 衝突対象に"OnHitBullet"メッセージ
        Debug.Log("OnGetItem");

        string tag = other.gameObject.tag;
        if (tag == "Object1")
        {

        }
        else if (tag == "Object2")
        {

        }
        // 自身のゲームオブジェクトを破棄
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Object1" || tag == "Object2")
        {
            GameObject tapicup = other.transform.parent.transform.parent.gameObject;
            tapicup.transform.localScale += Vector3.one * 0.5f;

            // 自身のゲームオブジェクトを破棄
            Destroy(gameObject);
        }
    }
}