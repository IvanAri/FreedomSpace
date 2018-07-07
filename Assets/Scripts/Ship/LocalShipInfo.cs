using UnityEngine;

/*The idea

    This class must have info about any parameter that should be used by other systems. 
    For example: engine.cs needs to know about ship acceleration and he will ask about this param
    from here and not from ShipNetworkController script, which should be used ONLY to synchronize
    important parameters. 

*/


public class LocalShipInfo : MonoBehaviour {

    private ShipNetworkController syncronizedInfo;

    public float currentShipSpeed;
    public float currentShipAcceleration;


	// Use this for initialization
	void Start () {

        syncronizedInfo = transform.GetComponent<ShipNetworkController>();

        currentShipSpeed = 0f;	

	}
	
	// Update is called once per frame
	void LateUpdate () {
        currentShipSpeed = syncronizedInfo.currentSpeed;
	}
}
