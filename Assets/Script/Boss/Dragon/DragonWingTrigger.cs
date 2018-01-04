using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWingTrigger : MonoBehaviour
{
    [SerializeField] protected GameObject gWing;
    
    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
            gWing.GetComponent<DragonWing>().IsProtect = false;
    }
}