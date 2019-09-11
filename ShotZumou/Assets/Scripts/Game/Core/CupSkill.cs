using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSkill : MonoBehaviour
{
    bool isCircleKeyDown;

    [SerializeField] string circle;
    [SerializeField] float canUseSkillSize = 3;
    [SerializeField] float useTapiAmount = 1.5f;
    GameObject canBombEffect;
    GameObject tapiBomber;

    // Start is called before the first frame update
    void Start()
    {
        isCircleKeyDown = false;

        canBombEffect = transform.Find("CanBombEffect").gameObject;
        tapiBomber = transform.Find("TapiBomber").gameObject;

        canBombEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (!GameCore.isStart)
        // {
        //     return;
        // }

        float scale = transform.localScale.x;
        Vector3 forEffectVector3 = new Vector3(scale - 1f, scale - 1f, scale - 1f);
        canBombEffect.transform.localScale = forEffectVector3;
        bool isOnCircle = Input.GetAxisRaw(circle) == 1 ? true : false;
        if (canUseSkillSize <= scale)
        {
            canBombEffect.SetActive(true);
            if (isOnCircle)
            {
                if (!isCircleKeyDown)
                {
                    transform.localScale -= Vector3.one * useTapiAmount;
                    tapiBomber.GetComponent<ParticleSystem>().Play();
                }

                isCircleKeyDown = true;
            }
        }
        else
        {
            canBombEffect.SetActive(false);
        }
        if (!isOnCircle)
        {
            isCircleKeyDown = false;
        }
    }
}