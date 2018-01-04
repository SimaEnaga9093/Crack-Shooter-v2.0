using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallStatus
{
    public float fAtk;
    public float fBonusDamage;
    public float fCriticalRate;

    public BallStatus(float fAtk, float fBonusDamage, float fCriticalRate)
    {
        this.fAtk = fAtk;
        this.fBonusDamage = fBonusDamage;
        this.fCriticalRate = fCriticalRate;
    }
}

public class Ball : MonoBehaviour
{
    public float fDuration;
    public bool bLost;
    
    protected BallStatus sStatus;
    public BallStatus Status { set { sStatus = value; } get { return sStatus; } }

    protected List<BuffSystem> lBuffRail;
    public List<BuffSystem> BuffRail { set { lBuffRail = value; } get { return lBuffRail; } }

    [SerializeField] protected GameObject gHitAnimation;
    [SerializeField] protected GameObject gMap;
    [SerializeField] protected GameObject gLost;

    public void Init()
    {
        sStatus = new BallStatus(0.0f, 0.0f, 0.0f);
        lBuffRail = new List<BuffSystem> { };
    }

    protected void Update()
    {
        if (transform.position.y <= -11.0f)
        {
            transform.transform.position = new Vector3(1.6f, -1.5f, -3.0f);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            gLost.SetActive(true);
            bLost = true;

            gMap.GetComponent<Map>().CharacterDamaged();
        }

        for (int i = 0; i < lBuffRail.Count; i++)
        {
            if (lBuffRail[i].Active)
                lBuffRail[i].BuffUpdate();
            else
                lBuffRail.RemoveAt(i);
        }

        if (bLost)
        {
            fDuration += Time.deltaTime;
            if (fDuration >= 0.15f)
            {
                gLost.SetActive(false);
                bLost = false;

                fDuration = 0.0f;
            }
        }
    }

    public void BuffCheck()
    {
        for (int i = 0; i < lBuffRail.Count; i++)
        {
            if (!lBuffRail[i].Active)
                continue;

            lBuffRail[i].BuffEffect();
        }
    }

    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<AudioSource>().Play();

        if(col.gameObject.tag == "Wall")
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -9.0f);
            gHitAnimation.GetComponent<Transform>().position = pos;
            gHitAnimation.GetComponent<Animator>().SetTrigger("Act");


        }
    }
}
