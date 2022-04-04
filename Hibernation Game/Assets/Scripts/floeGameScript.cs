using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floeGameScript : MonoBehaviour
{
    public static int numFloesBroken { get; set; }
    public GameObject floe;
    public GameObject endText;
    public GameObject timer;
    int floesToBreak;
    bool gameStarted;
    bool gameEnded;
    float startTime;
    GameObject myFloe;
    GameObject myTimer;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        gameStarted = false;
        gameEnded = false;
        floesToBreak = Random.Range(2,4);
        startTime = 999;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted)
        {
            myFloe = Instantiate(floe, new Vector3(0, 1.5f, 0), Quaternion.identity);
            myTimer = Instantiate(timer, new Vector3(0, 7.5f, 0), Quaternion.identity);
            gameStarted = true;
            startTime = Time.timeSinceLevelLoad;
        }
        if (GameObject.Find("floeDialog(Clone)") == null && gameEnded && Time.timeSinceLevelLoad > startTime + 1)
        {
            GlobalVars.floeDone = true;
            Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
            StartCoroutine(fadeOut(2));
        }
        //if (floesToBreak <= numFloesBroken && !gameEnded)
        //{
        //    Destroy(myFloe);
        //    Instantiate(endText, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        //    endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs.Add("You did good");
        //    gameEnded = true;

        //}
        if (Time.timeSinceLevelLoad > startTime + 20 && !gameEnded)
        {
            Destroy(myFloe);
            Destroy(myTimer);
            Instantiate(endText, new Vector3(53, 10, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            //endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs.Add("You did good");
            //endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs[0] = "You did good";
            //Debug.Log(endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs[0]);
            //endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().numDialogs = 1;
            startTime = Time.timeSinceLevelLoad;
            gameEnded = true;
        }
    }
    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName: "mainMap");
    }
}
