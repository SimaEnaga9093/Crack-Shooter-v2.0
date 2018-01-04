using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGahui : Character
{
    [SerializeField] protected GameObject Skill;

    protected override void SetStatus()
    {
        fMaxHp = 20.0f;
        fHp = fMaxHp;

        fAtk = 2.0f;
        fDef = 3.0f;

        fBonusDamage = 0.0f;
        fReduceDamage = 0.0f;

        fCriticalRate = 1.0f;
    }

    protected override void PassiveInit()
    {
        StartCoroutine("HpRegen");
    }

    public void OnMouseDown()
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
        Skill.GetComponent<Animator>().SetTrigger("Skill");
    }

    IEnumerator HpRegen()
    {
        for (int i = 0; i < 2; i++)
        {
            gAllyCharacter[i].GetComponent<Character>().Hp += 2.0f;
            if (gAllyCharacter[i].GetComponent<Character>().Hp >= gAllyCharacter[i].GetComponent<Character>().MaxHp)
                gAllyCharacter[i].GetComponent<Character>().Hp = gAllyCharacter[i].GetComponent<Character>().MaxHp;
        }

        yield return new WaitForSeconds(1.0f);
    }
}
