using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{

     public GameObject bContinue;
     public GameObject bReStart;
     public GameObject bMainMenu;
    public GameObject bOverlay;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Stop()
    {
      Time.timeScale = 0;

      bContinue.SetActive(true);

      bReStart.SetActive(true);

      bMainMenu.SetActive(true);

        bOverlay.SetActive(true);
    }
}
