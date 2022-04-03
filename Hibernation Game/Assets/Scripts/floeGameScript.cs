using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floeGameScript : MonoBehaviour
{
    public static int numFloesBroken { get; set; }
    public GameObject floe;
    public GameObject endText;
    int floesToBreak;
    bool gameStarted;
    bool gameEnded;
    GameObject myFloe;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        gameStarted = false;
        gameEnded = false;
        floesToBreak = Random.Range(2,4);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted)
        {
            myFloe = Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
            gameStarted = true;
        }
        if (GameObject.Find("DialogBox(Clone)") == null && gameEnded)
        {
            GlobalVars.completedMinigames++;
            SceneManager.LoadScene(sceneName: "mainMap");
        }
        if (floesToBreak <= numFloesBroken && !gameEnded)
        {
            Destroy(myFloe);
            Instantiate(endText, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs.Add("You did good");
            //StartCoroutine(delayedEndGame(2));
            gameEnded = true;

        }
    }
    //IEnumerator delayedEndGame(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    gameEnded = true;
    //}
}
