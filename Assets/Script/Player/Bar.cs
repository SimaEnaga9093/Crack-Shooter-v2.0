using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject[] gCharacter;

    public void Init()
    {
        gCharacter = new GameObject[2];
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            BallStatus status = col.gameObject.GetComponent<Ball>().Status;
            status = new BallStatus(0.0f, 0.0f, 0.0f);

            for (int i = 0; i < 2; i++)
            {
                status.fAtk += gCharacter[i].GetComponent<Character>().Atk;
                status.fBonusDamage += gCharacter[i].GetComponent<Character>().BonusDamage;
                status.fCriticalRate += gCharacter[i].GetComponent<Character>().CriticalRate;
            }
            status.fCriticalRate /= 2;

            col.gameObject.GetComponent<Ball>().Status = status;
            Debug.Log("Atk : " + status.fAtk.ToString());
            Debug.Log("BonusDamage : " + status.fBonusDamage.ToString());
            Debug.Log("CriticalRate : " + status.fCriticalRate.ToString());

            col.gameObject.GetComponent<Ball>().BuffCheck();
            Debug.Log("Buff Atk : " + status.fAtk.ToString());
            Debug.Log("Buff BonusDamage : " + status.fBonusDamage.ToString());
            Debug.Log("Buff CriticalRate : " + status.fCriticalRate.ToString());
        }
    }
}
