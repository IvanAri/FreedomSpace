using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public ExampleGameManager gameManager;

    // Way to triggering something
	void OnTriggerEnter()
    {

        gameManager.CompleteLevel();

    }

}
