using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmstarFlaw : MonoBehaviour
{
    protected bool bFlawAttack = false;
    public bool FlawAttack { get { return bFlawAttack; } }

    protected float fDuration = 0.0f;

    protected void Update()
    {
        if (bFlawAttack)
        {
            fDuration += Time.deltaTime;

            if (fDuration >= 1.0f)
            {
                bFlawAttack = false;
                fDuration = 0.0f;
            }
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
            bFlawAttack = true;
    }
}