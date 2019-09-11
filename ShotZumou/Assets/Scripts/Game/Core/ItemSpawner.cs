using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject ItemPrefab; // 出現させる敵のプレハブ

    GameObject Item;

    public void Spawn()
    {
        // 出現中でなければ敵を出現させる
        if (Item == null)
        {
            Item = Instantiate(ItemPrefab, transform.position, transform.rotation);
        }
    }
}
