using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public string mainMenu;

    public string restartLevel;

    public float waitRestart;

    public void RestarLevel()
    {
        SceneManager.LoadScene(restartLevel);
    }

    public void MenuUtama()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
