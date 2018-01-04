using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    [SerializeField]  public GameObject gBall;
    [SerializeField]  protected GameObject gMap;
    [SerializeField]  protected GameObject gLost;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (gBall.GetComponent<Transform>().transform.position.y <= -11.0f)
        {
            gLost.SetActive(true);
            gBall.GetComponent<Ball>().bLost = true;

            gMap.GetComponent<Map>().CharacterDamaged();
            gBall.transform.transform.position = new Vector3(1.6f, -1.5f, -6.0f);

            gBall.SetActive(false);

            GetComponent<Animator>().SetBool("Lost", true);

        }

        if (gBall.GetComponent<Ball>().bLost)
        {
            gBall.GetComponent<Ball>().fDuration += Time.deltaTime;
            if (gBall.GetComponent<Ball>().fDuration >= 0.15f)
            {
                gLost.SetActive(false);
                gBall.GetComponent<Ball>().bLost = false;

                gBall.GetComponent<Ball>().fDuration = 0.0f;
            }
        }
    }

    void Stop()
    {

        gBall.SetActive(true);
        GetComponent<Animator>().SetBool("Lost", false);

    }
}