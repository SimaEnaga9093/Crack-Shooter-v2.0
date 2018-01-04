using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Map
{
    override protected void SetStatus()
    {
        fMaxHp = 30.0f;
        fHp = fMaxHp;

        fAtk = 5.0f;
        fDef = 0.5f;

        fBonusDamage = 0.0f;
        fReduceDamage = 0.0f;
    }
}
