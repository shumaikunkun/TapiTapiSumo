using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForShumaPlayerPosition : MonoBehaviour
{
    public float speed=1.0f;

    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {

        //float leftX = Input.GetAxis("Horizontal");
        ////float leftY = Input.GetAxis("Vertical");

        //if (0 != leftX)
        //{
        //    //Debug.Log("左スティックX: " + leftX);
        //    transform.RotateAround(transform.position, Vector3.up, -speed* leftX);
        //}



        if (Input.GetKey(KeyCode.Z))
		{
			// 処理
			//Debug.Log("aaa");
            transform.RotateAround(transform.position, Vector3.up, speed);
		}

		if (Input.GetKey(KeyCode.X))
		{
			// 処理
			//Debug.Log("bbb");
			transform.RotateAround(transform.position, Vector3.up, -speed);
		}







    }
    

}



