using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMouth : MonoBehaviour
{
    [SerializeField] protected GameObject gDragon;

    protected float fDuration = 0.0f;
    protected bool bSwallow = false;

    protected GameObject gBall;
    

    protected void Update()
    {
        if (!bSwallow)
            return;

        fDuration += Time.deltaTime;
        gBall.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -3.0f);

        if (fDuration >= 2.0f)
        {
            Vector2 dir = new Vector2(1.0f, -1.0f);
            gBall.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 100);

            bSwallow = false;
            fDuration = 0.0f;
        }
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            bSwallow = true;
            gBall = col.gameObject;
            gDragon.GetComponent<Animator>().Play("DragonEat");
        }
    }
}
