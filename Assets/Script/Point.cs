using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    protected GameObject gMap;
    public GameObject Map { set { gMap = value; } }

    protected GameObject gBall;
    public GameObject Ball { set { gBall = value; } }

    public void Init()
    {
        //
    }

    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            float fAtk = gBall.GetComponent<Ball>().Status.fAtk;
            float fBonusDamage = gBall.GetComponent<Ball>().Status.fBonusDamage;
            float fCriticalRate = gBall.GetComponent<Ball>().Status.fCriticalRate;

            gMap.GetComponent<Map>().MapDamaged(fAtk, fBonusDamage, fCriticalRate);

            GetComponent<AudioSource>().Play();
        }
    }
}