using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player1のやつだけにつける
public class CupCollision : MonoBehaviour
{
    [SerializeField] AudioClip colSound;
    AudioSource colAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        colAudioSource = gameObject.AddComponent<AudioSource>();
        colAudioSource.clip = colSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;
        Debug.Log("dur");
        if (tag == "Object2")
        {
            colAudioSource.volume = 0.5f;
            colAudioSource.Play();
            Debug.Log("kaki");
        }
    }
}