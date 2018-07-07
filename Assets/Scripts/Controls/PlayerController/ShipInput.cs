using UnityEngine;



public class ShipInput : MonoBehaviour {

    private ShipNetworkController shipNetworkSyncronizer;

    void Start()
    {

        shipNetworkSyncronizer = transform.GetComponent<ShipNetworkController>();

    }
	
	// Update is called once per frame
	void Update () {

        handleInput();

	}

    void handleInput()
    {
        // Input for speed
        // change it for acceleration lately
        if (Input.GetKey("r"))
        {
            float curSpeed = shipNetworkSyncronizer.currentSpeed;
            shipNetworkSyncronizer.currentSpeed = Mathf.Min(Constants.MAX_SPEED, curSpeed + Constants.CHANGE_SPEED);
        }

        if (Input.GetKey("f"))
        {

            float curSpeed = shipNetworkSyncronizer.currentSpeed;
            shipNetworkSyncronizer.currentSpeed = Mathf.Max(0f, curSpeed - Constants.CHANGE_SPEED);
        }
    }
}
