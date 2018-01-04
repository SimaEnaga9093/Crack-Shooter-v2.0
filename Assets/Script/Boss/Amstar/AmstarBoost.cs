using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmstarBoost : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Vector2 vec = new Vector2(-1.0f, 1.0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(vec * 100.0f);
        }
    }
}
