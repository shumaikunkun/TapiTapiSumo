using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiState : MonoBehaviour
{
    [SerializeField]
    public int goldTapi = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddGoldTapi()
    {
        if (goldTapi < 99)
        {
            goldTapi++;
        }
    }
}