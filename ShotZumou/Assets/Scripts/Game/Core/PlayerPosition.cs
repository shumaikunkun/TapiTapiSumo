using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] string horizontal;
    public float speed = 1.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float leftX = Input.GetAxis(horizontal);

        if (0 != leftX)
        {
            transform.RotateAround(transform.position, Vector3.up, -speed * leftX);
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