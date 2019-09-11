using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] string r2Fire;
    [SerializeField] string l2Fire;

    [SerializeField] GameObject bulletPrefab; // 弾のプレハブ
    [SerializeField] GameObject superBulletPrefab; // 弾のプレハブ

    [SerializeField] Transform gunBarrelEnd; // 銃口(弾の発射位置)
    [SerializeField] int interval = 8; // 発射間隔

    //[SerializeField] ParticleSystem gunParticle;    // 発射時演出

    public AudioClip gunSound;
    AudioSource gunAudioSource; // タピオカの音源

    public AudioClip bombSound;
    AudioSource bombAudioSource; // ゴールデンタピオカの音源

    private int timeCount = 1;

    void Start()
    {
        gunAudioSource = gameObject.AddComponent<AudioSource>();
        gunAudioSource.clip = gunSound;
        bombAudioSource = gameObject.AddComponent<AudioSource>();
        bombAudioSource.clip = bombSound;
    }

    void Update()
    {
        if (!GameCore.isStart)
        {
            return;
        }
        // 入力に応じて押している間弾を発射する
        //発射間隔は変数で設定可能
        //bool isR2Fire = Input.GetKey(KeyCode.Space);
        bool isR2Fire = Input.GetAxisRaw(r2Fire) == 1 ? true : false;
        if (isR2Fire)
        {
            timeCount += 1;
            int v = timeCount % interval;
            if (v == 0)
            {
                Shoot();
            }
        }

        //bool isL2Fire = Input.GetKey(KeyCode.B);
        bool isL2Fire = Input.GetAxisRaw(l2Fire) == 1 ? true : false;
        if (isL2Fire)
        {
            timeCount += 1;
            int v = timeCount % interval;
            if (v == 0)
            {
                if (0 < GetComponent<TapiState>().goldTapi)
                {
                    GetComponent<TapiState>().goldTapi--;

                    SuperShoot();
                }
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
        gunAudioSource.Play();
    }
    void SuperShoot()
    {
        // プレハブを元に、シーン上に弾を生成
        Instantiate(superBulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        // 発射時演出
        //gunParticle.Play();

        // 発射時の音
        //gunAudioSource.Play();
        bombAudioSource.Play();
    }
}