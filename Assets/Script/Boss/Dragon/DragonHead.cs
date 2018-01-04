using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : Point
{
    [SerializeField] protected GameObject gDragon;

    protected float fDuration = 0.0f;

    protected void Update()
    {
        if (GetComponent<CircleCollider2D>().enabled)
            return;

        fDuration += Time.deltaTime;
        if (fDuration >= 2.5f)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            fDuration = 0.0f;
        }
    }

    override protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            base.OnCollisionEnter2D(col);
            GetComponent<CircleCollider2D>().enabled = false;
            gDragon.GetComponent<Animator>().Play("DragonHurt");
        }
    }
}