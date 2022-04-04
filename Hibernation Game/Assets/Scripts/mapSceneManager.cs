using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
                StartCoroutine(fadeOutSleep(2));
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
                Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
                StartCoroutine(fadeOutFloe(2));
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
                SceneManager.LoadScene(sceneName: "floeGame");
                Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
                StartCoroutine(fadeOutFloe(2));
            }
        }
    }
    void Start()
    {

        GameObject.FindGameObjectWithTag("music").GetComponent<musicScript>().PlayMusic();

        if (GlobalVars.eventDone == true)
        {
            DestroyObject(GameObject.Find("eventGame"));
        }

        //Debug.Log("Num minigames completed: " + GlobalVars.completedMinigames.ToString());
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
            Instantiate(activator, new Vector3(680, 95, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
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
