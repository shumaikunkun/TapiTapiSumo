using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;       // 弾のプレハブ
    [SerializeField] Transform gunBarrelEnd;        // 銃口(弾の発射位置)
    [SerializeField] int interval = 1;              // 発射間隔



    //[SerializeField] ParticleSystem gunParticle;    // 発射時演出
    //[SerializeField] AudioSource gunAudioSource;    // 発射音の音源
    private int timeCount = 1;

    void Update()
    {
        // 入力に応じて押している間弾を発射する
        //発射間隔は変数で設定可能
        if (Input.GetKey(KeyCode.Space))
        {
            timeCount += 1;
            int v = timeCount % interval;
            if (v == 0)
            {
                Shoot();
            }
        }
    }

    void OnDisable()
    {
        // Shoot処理を停止する
        CancelInvoke("Shoot");
    }

    // 弾を撃ったときの処理
    void Shoot()
    {
        // プレハブを元に、シーン上に弾を生成
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        // 発射時演出
        //gunParticle.Play();

        // 発射時の音
        //gunAudioSource.Play();
    }
}