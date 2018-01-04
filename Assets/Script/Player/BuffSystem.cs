using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem
{
    protected GameObject gBall;

    protected bool bActive;
    protected float fValue;
    protected float fDuration;

    protected float fCountTime;

    public bool Active { set { bActive = value; } get { return bActive; } }

    // -- //

    virtual public void BuffSet(GameObject gObject)
    {
        gBall = gObject;
        fCountTime = 0.0f;
    }

    virtual public void BuffEffect() { }
    
    public void BuffUpdate()
    {
        fCountTime += Time.deltaTime;
        if (fCountTime >= fDuration)
            bActive = false;
    }
}


public class Buff_AtkBoost : BuffSystem
{
    override public void BuffSet(GameObject gObject)
    {
        fValue = 15.0f;
        fDuration = 3.0f;

        base.BuffSet(gObject);
    }

    public override void BuffEffect()
    {
        BallStatus status = gBall.GetComponent<Ball>().Status;
        status.fAtk += status.fAtk * 15.0f / 100.0f;

        gBall.GetComponent<Ball>().Status = status;
    }
}


public class Buff_Critical : BuffSystem
{
    public override void BuffSet(GameObject gObject)
    {
        fValue = 100.0f;
        fDuration = 1.0f;

        base.BuffSet(gObject);
    }

    public override void BuffEffect()
    {
        BallStatus status = gBall.GetComponent<Ball>().Status;
        status.fCriticalRate = 100.0f;

        gBall.GetComponent<Ball>().Status = status;

    }
}