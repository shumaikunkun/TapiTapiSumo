using System.Collections;
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
        else if(tag == "Object2")
        {

        }
        // 自身のゲームオブジェクトを破棄
        Destroy(gameObject);
    }
}
