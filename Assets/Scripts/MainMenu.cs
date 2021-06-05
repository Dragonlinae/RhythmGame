using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void playGame() {
        SceneManager.LoadScene("Game1");
    }

    public void levelSelect() {
        SceneManager.LoadScene("Levels");
    }

    public void quitGame() {
        Application.Quit();
    }
}
