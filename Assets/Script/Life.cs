using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject LCharacter;
    public GameObject RCharacter;
    public GameObject PLife;
    public GameObject GameOver;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PLife.transform.localScale = new Vector2((LCharacter.GetComponent<CGahui>().fHp + RCharacter.GetComponent<CYunsung>().fHp) / 10, 1.5f);

        if(LCharacter.GetComponent<CGahui>().fHp <= 0 || RCharacter.GetComponent<CYunsung>().fHp <= 0)
        {
            GameOver.SetActive(true);
            PLife.SetActive(false);
        }
    }
}
