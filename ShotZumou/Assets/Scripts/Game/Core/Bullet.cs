﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f; // 弾速 [m/s]
    public GameObject bomb;

    //[SerializeField] ParticleSystem hitParticlePrefab; // 着弾時演出プレハブ

    // Use this for initialization
    void Start()
    {
        // ゲームオブジェクト前方向の速度ベクトルを計算
        var velocity = speed * transform.forward;

        // Rigidbodyコンポーネントを取得
        var rigidbody = GetComponent<Rigidbody>();

        // Rigidbodyコンポーネントを使って初速を与える
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {
        //衝突対象に"OnHitBullet"メッセージ
        //other.SendMessage("OnHitBullet");
        if (other.gameObject.tag == "Object1")
        {
            other.gameObject.transform.localScale += Vector3.one * 0.025f;
        }
        if (other.gameObject.tag == "Object2")
        {
            other.gameObject.transform.localScale += Vector3.one * 0.025f;
        }

        // 着弾地点に演出自動再生のゲームオブジェクトを生成
        Instantiate(bomb, transform.position, transform.rotation);

        // 自身のゲームオブジェクトを破棄
        Destroy(gameObject);

    }
}