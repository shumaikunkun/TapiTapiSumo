using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSkill : MonoBehaviour
{
    bool isCircleKeyDown;

    [SerializeField] string circle;
    [SerializeField] float canUseSkillSize = 3;
    [SerializeField] float useTapiAmount = 1.5f;
    GameObject tapiBomber;

    // Start is called before the first frame update
    void Start()
    {
        isCircleKeyDown = false;

        tapiBomber = transform.Find("TapiBomber").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!GameCore.isStart)
        // {
        //     return;
        // }

        bool isOnCircle = Input.GetAxisRaw(circle) == 1 ? true : false;
        if (isOnCircle)
        {
            if (!isCircleKeyDown)
            {
                float scale = transform.localScale.x;
                if (canUseSkillSize <= scale)
                {
                    transform.localScale -= Vector3.one * useTapiAmount;
                    tapiBomber.GetComponent<ParticleSystem>().Play();
                }

                isCircleKeyDown = true;
            }
        }
        if (!isOnCircle)
        {
            isCircleKeyDown = false;
        }
    }
}