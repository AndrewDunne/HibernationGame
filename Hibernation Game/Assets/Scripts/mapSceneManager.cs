using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapSceneManager : MonoBehaviour
{
    public GameObject floeText;
    public GameObject sleepText;
    public GameObject introText;
    bool clickable;
    public void sleeperGameClicked()
    {
        if (clickable)
        {
            if (!GlobalVars.sleepDone)
            {
                SceneManager.LoadScene(sceneName: "sleeperGame");
            }
            else
            {
                // already did sleep dialog
                Instantiate(sleepText, new Vector3(53, 10, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
                clickable = false;
            }
        }
    }
    public void floeGameClicked()
    {
        if (clickable)
        {
            if (!GlobalVars.floeDone)
            {
                SceneManager.LoadScene(sceneName: "floeGame");
            }
            else
            {
                // already did floe dialog
                Instantiate(floeText, new Vector3(53, 10, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
                clickable = false;
            }
        }
    }
    void Start()
    {

        GameObject.FindGameObjectWithTag("music").GetComponent<musicScript>().PlayMusic();

        Debug.Log("Num minigames completed: " + GlobalVars.completedMinigames.ToString());
        if(GlobalVars.sleepDone == true && GlobalVars.floeDone == true)
        {
            GlobalVars.sleepDone = false;
            GlobalVars.floeDone = false;
            GlobalVars.day++;
        }
        if (GlobalVars.intro == false)
        {
            // intro sequence
            GlobalVars.intro = true;
            clickable = false;
            Instantiate(introText, new Vector3(53, 10, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        }
        if (GlobalVars.day == 4)
        {
            // end sequence
        }

    }
    void Update()
    {
        if(!clickable && GameObject.Find(floeText.name + "(Clone)") == null && GameObject.Find(sleepText.name + "(Clone)") == null && GameObject.Find(introText.name + "(Clone)") == null)
        {
            clickable = true;
        }
    }
}
