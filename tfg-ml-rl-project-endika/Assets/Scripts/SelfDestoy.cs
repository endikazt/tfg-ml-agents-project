using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestoy : MonoBehaviour
{
    
    float selDestroyTimer; //milliseconds
    public float selDestroyTimerLimit = 1000; //milliseconds


    void Start()
    {
        this.selDestroyTimer = 0;
    }

    void Update()
    {
            if(this.selDestroyTimer < this.selDestroyTimerLimit)
            {
                this.selDestroyTimer++;
            }

            if(this.selDestroyTimer >= this.selDestroyTimerLimit)
            {
               Object.Destroy(this.gameObject);
            }
    }
}
