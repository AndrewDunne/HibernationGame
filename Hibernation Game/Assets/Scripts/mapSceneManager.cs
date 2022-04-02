using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapSceneManager : MonoBehaviour
{
    public void sleeperGameClicked()
    {
        SceneManager.LoadScene(sceneName: "sleeperGame");
    }
    public void floeGameClicked()
    {
        SceneManager.LoadScene(sceneName: "floeGame");
    }
    void Start()
    {
        Debug.Log("Num minigames completed: " + GlobalVars.completedMinigames.ToString());
    }
}
