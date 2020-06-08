using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactivate : MonoBehaviour
{
    public GameObject lifeCube;
    float reactivateTimer; //milliseconds
    public float reactivateTimerLimit = 500; //milliseconds

    void Start()
    {
        this.reactivateTimer = 0;
    }

    void Update()
    {

        if(lifeCube.activeInHierarchy == false)
        {
            if(reactivateTimer < reactivateTimerLimit)
            {
                reactivateTimer++;
            }

            if(reactivateTimer >= reactivateTimerLimit)
            {
                lifeCube.SetActive(true);
                this.reactivateTimer = 0;
            }
        }
    }
}
