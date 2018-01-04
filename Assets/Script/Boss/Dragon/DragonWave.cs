using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWave : MonoBehaviour
{
    [SerializeField] protected GameObject gCamera;
    [SerializeField] protected GameObject gStoneShower;

    protected float fDuration = 0.0f;

    protected void Update()
    {
        fDuration += Time.deltaTime;
        if (fDuration >= 1.5f)
        {
            if (Random.Range(0, 2) == 1)
            {
                GetComponent<Animator>().SetTrigger("Wave");
                StartCoroutine("Shake");
            }
            fDuration = 0.0f;
        }
    }

    IEnumerator Shake()
    {
        gStoneShower.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        gStoneShower.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gStoneShower.transform.position = new Vector3(0.0f, 20.0f, -7.0f);
        yield return new WaitForSeconds(0.6f);
        gStoneShower.GetComponent<Rigidbody2D>().gravityScale = 8.0f;
        //gStoneShower.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10.0f);

        Vector2 vec;
        vec = new Vector2(-0.3f, 0.0f);
        gCamera.transform.Translate(vec);

        yield return new WaitForSeconds(0.07f);

        vec = new Vector2(0.6f, 0.0f);
        gCamera.transform.Translate(vec);

        yield return new WaitForSeconds(0.07f);

        vec = new Vector2(-0.3f, 0.0f);
        gCamera.transform.Translate(vec);
    }
}
