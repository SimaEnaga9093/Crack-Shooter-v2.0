using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmstarPoint : Point
{
    protected bool bReset = false;
    protected float fDuration = 0.0f;

    protected void Update()
    {
        if (bReset)
        {
            gBall.transform.position = new Vector3(1.05f, -0.22f, -6.0f);

            fDuration += Time.deltaTime;
            if (fDuration >= 1.0f)
            {
                gBall.GetComponent<SpriteRenderer>().enabled = true;

                fDuration = 0.0f;
                bReset = false;
            }
        }
    }

    override protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            base.OnCollisionEnter2D(col);

            bReset = true;
            gBall.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
