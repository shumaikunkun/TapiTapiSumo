using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSample : MonoBehaviour
{
    [SerializeField] string horizontal;
    [SerializeField] string vertical;
    [SerializeField] string horizontalView;
    [SerializeField] string verticalView;
    [SerializeField] string l2Fire;
    [SerializeField] string r2Fire;
    [SerializeField] string circle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ----- 左スティック ----- //
        float leftX = Input.GetAxis(horizontal);
        float leftY = Input.GetAxis(vertical);

        if (0 != leftX)
        {
            Debug.Log("左スティックX: " + leftX + "   " + horizontal);
        }
        if (0 != leftY)
        {
            Debug.Log("左スティックY: " + leftY + "   " + vertical);
        }
        // ----- ---------- ----- //

        // ----- 右スティック ----- //
        float rightX = Input.GetAxis(horizontalView);
        float rightY = Input.GetAxis(verticalView);

        if (0 != rightX)
        {
            Debug.Log("右スティックX: " + rightX + "   " + horizontalView);
        }
        if (0 != rightY)
        {
            Debug.Log("右スティックY: " + rightY + "   " + verticalView);
        }
        // ----- ---------- ----- //

        // ----- L2 R2 Circle ----- //
        float l2 = Input.GetAxis(l2Fire);
        float r2 = Input.GetAxis(r2Fire);
        float cir = Input.GetAxis(circle);

        if (0 != l2)
        {
            Debug.Log("L2: " + l2 + "   " + l2Fire);
        }
        if (0 != r2)
        {
            Debug.Log("R2:" + r2 + "   " + r2Fire);
        }
        if (0 != cir)
        {
            Debug.Log("Circle:" + cir + "   " + circle);
        }
        // ----- ---------- ----- //
    }
}