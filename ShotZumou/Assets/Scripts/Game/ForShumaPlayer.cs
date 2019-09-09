using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForShumaPlayer : MonoBehaviour
{
    public float speed=1.0f;

    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("update");

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// 処理
			//Debug.Log("aaa");
            transform.RotateAround(transform.position, Vector3.up, speed);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// 処理
			//Debug.Log("bbb");
			transform.RotateAround(transform.position, Vector3.up, -speed);
		}
    }
    

}
