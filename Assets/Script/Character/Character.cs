using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float fHp;
    protected float fMaxHp;
    public float Hp { set { fHp = value; } get { return fHp; } }
    public float MaxHp { set { fMaxHp = value; } get { return fMaxHp; } }

    protected float fAtk;
    protected float fDef;
    public float Atk { set { fAtk = value; } get { return fAtk; } }
    public float Def { set { fDef = value; } get { return fDef; } }

    protected float fBonusDamage;
    protected float fReduceDamage;
    public float BonusDamage { set { fBonusDamage = value; } get { return fBonusDamage; } }
    public float ReduceDamage { set { fReduceDamage = value; } get { return fReduceDamage; } }

    protected float fCriticalRate;
    public float CriticalRate { set { fCriticalRate = value; } get { return fCriticalRate; } }

    protected GameObject[] gAllyCharacter;
    protected GameObject gBall;
    public GameObject Ball { set { gBall = value; } }

    // -- //

    public void Init()
    {
        SetStatus();
        
        PassiveInit();
    }

    protected void Update()
    {
        if (fHp <= 0)
            Death();

        PassiveUpdate();
    }

    // -- //
    
    virtual protected void SetStatus()
    {
        fMaxHp = 10.0f;
        fHp = fMaxHp;

        fAtk = 1.0f;
        fDef = 0.5f;

        fBonusDamage = 0.0f;
        fReduceDamage = 0.0f;

        fCriticalRate = 1.0f;
    }

    virtual protected void PassiveInit()
    {
        // 단발 스킬 효과를 여기에
    }

    virtual protected void PassiveUpdate()
    {
        // 유지 스킬 효과를 여기에
    }

    virtual protected void GetDamaged()
    {
        // 피해를 입을 시 효과를 여기에
    }

    public void Damage(float fAtk, float fBonusDamage = 0.0f)
    {
        // 데미지 공식 : 가하는 쪽의 공격력 * 100 / (100 + 받는 쪽의 방어력) + 추가 피해 - 피해 경감
        this.fHp -= fAtk * 100 / (100 + this.fDef) + fBonusDamage - this.fReduceDamage;
        GetDamaged();
    }

    protected void Death()
    {
        gameObject.SetActive(false);
    }

    // -- //

    public void SetCharacter(GameObject[] gAllyCharacter)
    {
        this.gAllyCharacter = gAllyCharacter;
    }
}
