using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CYunsung : Character
{
    [SerializeField] protected GameObject Skill;

    protected override void SetStatus()
    {
        fMaxHp = 25.0f;
        fHp = fMaxHp;

        fAtk = 5.0f;
        fDef = 2.0f;

        fBonusDamage = 0.0f;
        fReduceDamage = 0.0f;

        fCriticalRate = 5.0f;
    }

    protected void OnMouseDown()
    {
        CriticalBurst();
    }

    protected void CriticalBurst()
    {
        Buff_Critical sCritical = new Buff_Critical();
        sCritical.Active = true;
        sCritical.BuffSet(gBall);

        List<BuffSystem> rail = gBall.GetComponent<Ball>().BuffRail;
        rail.Add(sCritical);
        gBall.GetComponent<Ball>().BuffRail = rail;
        Skill.GetComponent<Animator>().SetTrigger("Skill");
    }

    protected override void GetDamaged()
    {
        AtkBoost();
    }

    protected void AtkBoost()
    {
        Buff_AtkBoost sAtkBoost = new Buff_AtkBoost();
        sAtkBoost.Active = true;
        sAtkBoost.BuffSet(gBall);

        List<BuffSystem> rail = gBall.GetComponent<Ball>().BuffRail;
        rail.Add(sAtkBoost);
        gBall.GetComponent<Ball>().BuffRail = rail;
    }
}
