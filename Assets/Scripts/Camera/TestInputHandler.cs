using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputHandler : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // here we are going to read players input

        if (Input.GetKey(KeyCode.R)) {

            Transform target = GameObject.Find("RedCube").transform;
            this.GetComponentInParent<LookAtTarget>().ReceiveTarget(target);

        }

        if (Input.GetKey(KeyCode.G))
        {

            Transform target = GameObject.Find("GreenCube").transform;
            this.GetComponentInParent<LookAtTarget>().ReceiveTarget(target);

        }

        if (Input.GetKey(KeyCode.B))
        {

            Transform target = GameObject.Find("BlueCube").transform;
            this.GetComponentInParent<LookAtTarget>().ReceiveTarget(target);

        }

    }


}
