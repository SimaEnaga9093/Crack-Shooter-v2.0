using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {


    public GameObject bContinue;
    public GameObject bReStart;
    public GameObject bMainMenu;
    public GameObject bOverlay;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Play()
    {
        Time.timeScale = 1;
   
        bReStart.SetActive(false);
        bMainMenu.SetActive(false);
        bContinue.SetActive(false);
        bOverlay.SetActive(false);
    }
}
