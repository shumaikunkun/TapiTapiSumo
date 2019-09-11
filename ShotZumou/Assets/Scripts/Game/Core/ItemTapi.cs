using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTapi : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // 衝突対象に"OnHitBullet"メッセージ
        other.SendMessage("OnGetItem");

        // 自身のゲームオブジェクトを破棄
        Destroy(gameObject);
    }
}
