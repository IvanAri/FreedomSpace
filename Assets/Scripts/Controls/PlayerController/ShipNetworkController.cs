using UnityEngine;
using UnityEngine.Networking;

public static class Constants
{
    public const string PREFAB_AXIS = "Prefabs/NavAxis";
    public const float MAX_SPEED = 5f;
    public const float CHANGE_SPEED = 0.1f;
}


public class ShipNetworkController : NetworkBehaviour
{
    public GameObject axisObj;
    public Transform navAxis;

    public float rotationSpeed = 100f;
    public float currentSpeed = 0f;

    void Start()
    {
        if (!isLocalPlayer)
        {
            this.transform.Find("PivotPoint").gameObject.SetActive(false);
            return;
        }
        GameObject axisObj = Instantiate(Resources.Load<GameObject>(Constants.PREFAB_AXIS));
        axisObj.GetComponent<AxisController>().mainAxis = this.GetComponent<Transform>();
        navAxis = axisObj.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;
        handleInput();
        transform.position += transform.forward *  currentSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocalPlayer)
            return;
        transform.rotation = Quaternion.Slerp(transform.rotation, navAxis.rotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDestroy()
    {
        Destroy(axisObj);
        axisObj = null;
        navAxis = null;
    }

    void handleInput()
    {
        if (Input.GetKey("r"))
        {
            currentSpeed = Mathf.Min(Constants.MAX_SPEED, currentSpeed + Constants.CHANGE_SPEED);
        }

        if (Input.GetKey("f"))
        {
            currentSpeed = Mathf.Max(0f, currentSpeed - Constants.CHANGE_SPEED);
        }
    }
}
