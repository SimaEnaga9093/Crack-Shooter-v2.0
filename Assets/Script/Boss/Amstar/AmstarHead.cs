using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmstarHead : MonoBehaviour
{
    protected float fDuration = 0.0f;
    protected bool bHurt = false;

    public bool hit = false;

    protected void Update()
    {
        if (bHurt)
        {
            fDuration += Time.deltaTime;
            if (fDuration >= 5.0f)
            {
                bHurt = false;
                hit = false;
                fDuration = 0.0f;

                GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            bHurt = true;
            hit = true;
            GetComponent<Animator>().SetTrigger("Hurt");
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}