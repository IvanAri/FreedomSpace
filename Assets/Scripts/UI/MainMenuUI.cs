using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MainMenuButtons
{
    Tutorial = 0,
    Customization = 1,
    Multiplayer = 2,
    Quit = 3,
}

public class MainMenuUI : MonoBehaviour {

    const int MAIN_MENU_BUTTONS_COUNT = 4;
    GameObject[] buttonsList = null;

    // Use this for initialization
    void Start () {
		
        buttonsList = GameObject.FindGameObjectsWithTag("button");

        

	}

    void SortButtonsByHeight()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
