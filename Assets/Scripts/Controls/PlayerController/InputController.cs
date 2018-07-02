using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum COMMAND
{
    DoNothing = 0,
}

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Method that will exec the command
    bool Execute(List<COMMAND> commandsList)
    {   
        return true;
    }
}
