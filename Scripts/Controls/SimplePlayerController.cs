using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour {

    public float hSpeed = 150.0f;
    public float vSpeed = 3.0f;

	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * hSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vSpeed;

        if (Input.GetButton("Up"))
        {
            print("You've inputed Up");
        }

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
		
	}
}
