using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] protected GameObject gPoint;
    [SerializeField] protected GameObject gHitBarL;
    [SerializeField] protected GameObject gHitBarR;
    [SerializeField] protected GameObject gBall;
    [SerializeField] protected GameObject[] gCharacter;

    [SerializeField] protected GameObject gBoss;
    [SerializeField] protected GameObject gDeath;

    [SerializeField] protected GameObject Hpbar;
    [SerializeField] protected GameObject Clear;

    protected float fHp;
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

    //protected void Init()
    public void Start()
    {
        SetStatus();

        gPoint.GetComponent<Point>().Map = gameObject;
        gPoint.GetComponent<Point>().Init();
        gPoint.GetComponent<Point>().Ball = gBall;

        //gCharacter = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            gCharacter[i].GetComponent<Character>().SetCharacter(gCharacter);
            gCharacter[i].GetComponent<Character>().Ball = gBall;
            gCharacter[i].GetComponent<Character>().Init();
        }

        gHitBarL.GetComponent<HitBar>().Dir = HitBarDir.LEFT;
        gHitBarL.GetComponent<HitBar>().Init();
        gHitBarL.GetComponent<HitBar>().SetCharacter(gCharacter);
        gHitBarR.GetComponent<HitBar>().Dir = HitBarDir.RIGHT;
        gHitBarR.GetComponent<HitBar>().Init();
        gHitBarR.GetComponent<HitBar>().SetCharacter(gCharacter);

        gBall.GetComponent<Ball>().Init();
    }

    virtual protected void Update()
    {
        if (fHp <= 0)
            Death();

        Hpbar.transform.localScale = new Vector2(fHp / 10, 1.5f);

        if (fHp <= 0)
        {
            gBoss.SetActive(false);
            gDeath.SetActive(true);
            Hpbar.SetActive(false);
            Clear.SetActive(true);
        }
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
    }

    public void MapDamaged(float fAtk, float fBonusDamage, float fCriticalRate)
    {
        float fDamage = fAtk * 100 / (100 + this.fDef) + fBonusDamage - this.fReduceDamage;
        if (Random.Range(0.0f, 100.0f) <= fCriticalRate)
            fDamage += fDamage * 50.0f / 100.0f;
        this.fHp -= fDamage;

        Debug.Log(fDamage.ToString());
    }

    protected void Death()
    {
        gBoss.SetActive(false);
        gDeath.SetActive(true);
    }

    public void CharacterDamaged()
    {
        for (int i = 0; i < 2; i++)
            gCharacter[i].GetComponent<Character>().Damage(fAtk, fBonusDamage);
    }
}
