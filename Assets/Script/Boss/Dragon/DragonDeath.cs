using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDeath : MonoBehaviour
{
    protected float fDuration = 0.0f;
    protected bool bShakeDir = true;
    

    protected void Update()
    {

        fDuration += Time.deltaTime;
        if (fDuration >= 0.1f)
        {
            Vector2 vec;
            if (bShakeDir)
            {
                vec = new Vector2(-0.6f, 0.0f);
                bShakeDir = false;
            }
            else
            {
                vec = new Vector2(0.6f, 0.0f);
                bShakeDir = true;
            }
            transform.Translate(vec);
            fDuration = 0.0f;
        }
    }
}
