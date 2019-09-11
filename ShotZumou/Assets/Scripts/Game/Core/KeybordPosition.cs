using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybordPosition : MonoBehaviour
{
    //[SerializeField] string horizontal;
    public float speed = 1.0f;
    float left = 0;
    float right = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        left = Input.GetKey(KeyCode.Z) ? -1.0f : 0f;
        right = Input.GetKey(KeyCode.C) ? 1.0f : 0f;

        float horizontal = left + right;

        if (0 != horizontal)
        {
            transform.RotateAround(transform.position, Vector3.up, -speed * horizontal);
        }

        // if (Input.GetKey(KeyCode.Z))
        // {
        //     // 処理
        //     //Debug.Log("aaa");
        //     transform.RotateAround(transform.position, Vector3.up, speed);
        // }

        // if (Input.GetKey(KeyCode.X))
        // {
        //     // 処理
        //     //Debug.Log("bbb");
        //     transform.RotateAround(transform.position, Vector3.up, -speed);
        // }
    }
}