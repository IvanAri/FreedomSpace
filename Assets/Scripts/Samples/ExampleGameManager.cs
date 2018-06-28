using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleGameManager : MonoBehaviour {

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    // TODO: https://www.youtube.com/watch?v=Iv7A8TzreY4&index=10&list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            Invoke("Restart", restartDelay);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("Level WON!");
        completeLevelUI.SetActive(true);
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	
}
