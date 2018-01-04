using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmstarBubble : MonoBehaviour
{
    [SerializeField] protected bool bHard;

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (!bHard)
            {
                GetComponent<Animator>().Play("Bubble");
                GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<Animator>().Play("BubbleHard");
            }
        }
    }
}
