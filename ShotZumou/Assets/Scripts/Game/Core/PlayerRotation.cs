using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] string horizontalView;
    [SerializeField] string verticalView;

    public float speed = 1.0f;

    [SerializeField] float angularVelocity = 50f; // 回転速度の設定​

    float horizontalAngle = 0f; // 水平方向の回転量を保存
    float verticalAngle = 0f; // 垂直方向の回転量を保存​

    void Update()
    {
        //// 入力による回転量を取得
        //var horizontalRotation = Input.GetAxis("Horizontal")  * angularVelocity * Time.deltaTime;
        //var verticalRotation = -Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;

        var horizontalRotation = Input.GetAxis(horizontalView) * angularVelocity * Time.deltaTime;
        var verticalRotation = -Input.GetAxis(verticalView) * angularVelocity * Time.deltaTime;

        // 回転量を更新
        horizontalAngle += horizontalRotation;
        verticalAngle += verticalRotation;

        // 垂直方向は回転し過ぎないように制限
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);

        // Transformコンポーネントに回転量を適用する
        transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);

        //float leftX = Input.GetAxis("Horizontal");
        //float leftY = Input.GetAxis("Vertical");

        //if (0 != leftX)
        //{
        //    //Debug.Log("左スティックX: " + leftX);
        //    transform.RotateAround(transform.position, Vector3.up, speed * leftX);
        //}

        //if (0 != leftY)
        //{
        //    //Debug.Log("左スティックX: " + leftX);
        //    transform.RotateAround(transform.position, Vector3.left, speed * leftY);
        //}

    }
}