using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ItemPrefab = new GameObject[2]; // 出現させるプレハブ

    GameObject Item;

    public void Spawn()
    {
        var index = Random.Range(0, 2);

        // 出現中でなければ敵を出現させる
        if (Item == null)
        {
            Item = Instantiate(ItemPrefab[index], transform.position, transform.rotation);
        }
    }
}