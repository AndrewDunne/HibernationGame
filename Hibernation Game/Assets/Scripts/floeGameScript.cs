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
    GameObject myFloe;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        gameStarted = false;
        //floesToBreak = Random.Range(2,4);
        floesToBreak = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted)
        {
            myFloe = Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
            gameStarted = true;
        }
        if (floesToBreak <= numFloesBroken)
        {
            Destroy(myFloe);
            Instantiate(endText, new Vector3(0, 0, 0), Quaternion.identity);
            //Debug.Log(endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>());
            endText.transform.GetChild(0).gameObject.GetComponent<dialogSystem>().dialogs.Add("You did good");
            
            //GlobalVars.completedMinigames++;
            //SceneManager.LoadScene(sceneName: "mainMap");
        }
    }
}
