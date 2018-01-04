using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public GameObject Stage;
    int ThisStage;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Re()
    {
        ThisStage = Stage.GetComponent<CheckStage>().Stage;

        if(ThisStage == 1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Dungeon_Dragon");
        }

        if (ThisStage == 2)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Dungeon_Amstar");
        }

    }
}
