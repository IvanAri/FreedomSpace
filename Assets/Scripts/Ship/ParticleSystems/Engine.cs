using UnityEngine;

public class Engine : MonoBehaviour {

    private LocalShipInfo localInfo;
    private ParticleSystem exhaust;

	// Use this for initialization
	void Start () {
        localInfo = transform.parent.GetComponent<LocalShipInfo>();
        exhaust = transform.GetComponent<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {

        var main = exhaust.main;
        main.startLifetimeMultiplier = Mathf.Clamp(localInfo.currentShipSpeed / 10, 0, 1);

	}
}
