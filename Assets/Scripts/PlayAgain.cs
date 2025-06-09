using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    void Start()
    {
        //GameObject.Find("Play again").GetComponentInChildren<Text>().text = "Play once more";
    }

    public void PlayOnceMore()
    {
        Debug.Log("Gettin clicked");
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
