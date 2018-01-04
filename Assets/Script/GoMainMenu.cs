using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectMenu");
    }
}
