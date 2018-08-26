using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputHandler : MonoBehaviour {

    public float movingDistance = 1.0f;
    public float movingSpeed = 1.0f;

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

        // A little bit of moving for tests
        if (Input.GetKey(KeyCode.A))
        {
            var newPosition = new Vector3(transform.position.x - movingDistance, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * movingSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {

            var newPosition = new Vector3(transform.position.x + movingDistance, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * movingSpeed);

        }

    }


}
