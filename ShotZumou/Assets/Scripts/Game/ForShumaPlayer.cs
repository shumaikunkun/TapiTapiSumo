using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForShumaPlayer : MonoBehaviour
{
    public GameObject player;
    //  動かしたいプレイヤー
    bool right = false;
    //  右ボタンを押しているかの真偽値
    bool left = false;
    //  左ボタンを押しているかの真偽値


    // Use this for initialization
    void Start()
    {
		Debug.Log("start");
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("update");

		if (Input.GetKey(KeyCode.UpArrow))
		{
			// 処理
            Debug.Log("aaa");
			transform.position += new Vector3(5.0f * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			// 処理
			Debug.Log("bbb");
			transform.position += new Vector3(-5.0f * Time.deltaTime, 0, 0);
		}



		if (right)
        {
            goright();
            //          右に動かすためのメソッドを呼び出す
        }
        else if (left)
        {
            goleft();
            //          左に動かすためのメソッドを呼び出す
        }
        else
        {
            //          ボタンを押していない時
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //          プレイヤーを元の角度に戻す
        }
    }

    public void rPushDown()
    {
        //      右ボタンを押している間
        right = true;
    }

    public void rPushUp()
    {
        //      右ボタンを押すのをやめた時
        right = false;
    }

    public void lPushDown()
    {
        //      左ボタンを押している間
        left = true;
    }

    public void lPushUp()
    {
        //      左ボタンを押すのをやめた時
        left = false;
    }

    public void goright()
    {

            transform.position += new Vector3(5.0f * Time.deltaTime, 0, 0);
            //          プレイヤーをx軸方向に秒速5.0fで動かす

    }

    public void goleft()
    {

            transform.position += new Vector3(-5.0f * Time.deltaTime, 0, 0);
            //          プレイヤーをx軸方向に秒速-5.0fで動かす

    }
    

}
