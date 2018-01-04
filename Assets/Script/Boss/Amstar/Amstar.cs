using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amstar : Map
{
    [SerializeField] protected GameObject gFlaw;

    protected bool bSpin = false;
    protected bool bSpinAfter = false;

    protected override void SetStatus()
    {
        fMaxHp = 30.0f;
        fHp = fMaxHp;

        fAtk = 5.0f;
        fDef = 0.5f;

        fBonusDamage = 0.0f;
        fReduceDamage = 0.0f;
    }

    protected override void Update()
    {
        base.Update();
        SpinCheck();
    }

    protected void SpinCheck()
    {
        if (fHp <= 15.0f && !bSpinAfter)
            bSpin = true;
        gBoss.GetComponent<Animator>().SetBool("Spin", bSpin);

        if (bSpin && gFlaw.GetComponent<AmstarFlaw>().FlawAttack)
        {
            bSpin = false;
            bSpinAfter = true;
        }
    }
}
