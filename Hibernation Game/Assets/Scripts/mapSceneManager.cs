using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapSceneManager : MonoBehaviour
{
    public GameObject floeText;
    public GameObject sleepText;
    public GameObject introText;
    public GameObject activator;
    bool clickable;
    public void sleeperGameClicked()
    {
        if (clickable)
        {
            if (!GlobalVars.sleepDone)
            {
                SceneManager.LoadScene(sceneName: "sleeperGame");
                //Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
                //StartCoroutine(fadeOutSleep(2));
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
    public void eventGameClicked()
    {
        if (clickable)
        {
            if (!GlobalVars.eventDone)
            {
                if (GlobalVars.day == 2)
                {
                    SceneManager.LoadScene(sceneName: "chordShore");
                }
                else if(GlobalVars.day == 3)
                {
                    SceneManager.LoadScene(sceneName: "cinna");
                }
            }
        }
    }
    void Start()
    {

        GameObject.FindGameObjectWithTag("music").GetComponent<musicScript>().PlayMusic();
        GameObject.FindGameObjectWithTag("wind").GetComponent<musicScript>().PlayMusic();
        if (GlobalVars.day == 0)
        {
            GlobalVars.day = 1;
            GlobalVars.eventDone = true;
        }

        //Debug.Log("Num minigames completed: " + GlobalVars.completedMinigames.ToString());
        if (GlobalVars.sleepDone == true && GlobalVars.floeDone == true)
        {
            GlobalVars.sleepDone = false;
            GlobalVars.floeDone = false;
            GlobalVars.eventDone = false;
            GlobalVars.day++;
        }
        if (GlobalVars.eventDone == true)
        {
            DestroyObject(GameObject.Find("eventGame"));
            DestroyObject(GameObject.Find("sparkles"));
        }
        if (GlobalVars.intro == false)
        {
            // intro sequence
            GlobalVars.intro = true;
            clickable = false;
            Instantiate(introText, new Vector3(53, 10, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(activator, new Vector3(680, 95, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        }
        if (GlobalVars.day == 4)
        {
            SceneManager.LoadScene(sceneName: "outro");
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
    IEnumerator fadeOutFloe(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName: "floeGame");
    }
    IEnumerator fadeOutSleep(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName: "sleeperGame");
    }
}
