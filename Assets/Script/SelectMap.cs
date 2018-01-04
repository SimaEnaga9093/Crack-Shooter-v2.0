using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public GameObject mDragon;
    public GameObject mAmStar;
 
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
  
    }

    public void Select()
    {
        if (mDragon.GetComponent<Transform>().localScale.x == 1 && mDragon.GetComponent<Select>().Is == false)
        {
            mDragon.GetComponent<Select>().Is = true;
            mAmStar.GetComponent<Select>().Is = false;

            mAmStar.transform.localScale = new Vector2(0.8f, 0.8f);
            mAmStar.transform.localPosition = new Vector3(700.0f, 0.0f, 0.0f);
        }

        if (mAmStar.GetComponent<Transform>().localScale.x == 1 && mAmStar.GetComponent<Select>().Is == false)
        {
            mAmStar.GetComponent<Select>().Is = true;
            mDragon.GetComponent<Select>().Is = false;

            mDragon.transform.localScale = new Vector2(0.8f, 0.8f);
            mDragon.transform.localPosition = new Vector3(-700.0f, 0.0f, 0.0f);
        }
    }
}
