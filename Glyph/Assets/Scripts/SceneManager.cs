using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public AudioSource Button;

    public void ReplayGame()
    {
        StartCoroutine(Delay(SceneManager.GetActiveScene().buildIndex)); // Reload the current scene
    }

    public void PlayGame()
    {
        StartCoroutine(Delay(1)); // Change the number based on the scene you want to load
    }

    IEnumerator Delay(int sceneNumber)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
