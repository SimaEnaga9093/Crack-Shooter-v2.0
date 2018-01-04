using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{

    public int stage;
    public bool Is;

    // Use this for initialization

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pick()
    {
       
        if (GetComponent<Transform>().position.x == 0)
        { 
            if (stage == 1 && GetComponent<Transform>().localScale.x == 1)
            {
                SceneManager.LoadScene("Dungeon_Dragon");
            }

            else if (stage == 2 && GetComponent<Transform>().localScale.x == 1)
            {
                SceneManager.LoadScene("Dungeon_Amstar");
            }
        }

        else if (GetComponent<Transform>().position.x != 0)
        {
            transform.localScale = new Vector2(1, 1); 
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}

