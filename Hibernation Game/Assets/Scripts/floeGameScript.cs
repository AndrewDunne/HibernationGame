using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floeGameScript : MonoBehaviour
{
    public static int numFloesBroken { get; set; }
    public GameObject floe;
    int floesToBreak;
    bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        gameStarted = false;
        floesToBreak = Random.Range(2,4);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted)
        {
            Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
            gameStarted = true;
        }
        if (floesToBreak <= numFloesBroken)
        {
            GlobalVars.completedMinigames++;
            SceneManager.LoadScene(sceneName: "mainMap");
        }
    }
}
