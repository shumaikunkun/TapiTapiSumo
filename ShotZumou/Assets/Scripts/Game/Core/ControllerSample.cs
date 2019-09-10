using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ----- 左スティック ----- //
        float leftX = Input.GetAxis("Horizontal");
        float leftY = Input.GetAxis("Vertical");

        if (0 != leftX)
        {
            Debug.Log("左スティックX: " + leftX);
        }
        if (0 != leftY)
        {
            Debug.Log("左スティックY:" + leftY);
        }
        // ----- ---------- ----- //

        // ----- 右スティック ----- //
        float rightX = Input.GetAxis("HorizontalView");
        float rightY = Input.GetAxis("VerticalView");

        if (0 != rightX)
        {
            Debug.Log("右スティックX: " + rightX);
        }
        if (0 != rightY)
        {
            Debug.Log("右スティックY:" + rightY);
        }
        // ----- ---------- ----- //

        // ----- L2 R2 Circle ----- //
        float l2 = Input.GetAxis("L2Fire");
        float r2 = Input.GetAxis("R2Fire");
        float circle = Input.GetAxis("Circle");

        if (0 != l2)
        {
            Debug.Log("L2: " + l2);
        }
        if (0 != r2)
        {
            Debug.Log("R2:" + r2);
        }
        if (0 != circle)
        {
            Debug.Log("Circle:" + circle);
        }
        // ----- ---------- ----- //
    }
}