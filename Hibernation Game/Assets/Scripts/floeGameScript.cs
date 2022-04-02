using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floeGameScript : MonoBehaviour
{
    public static int numFloesBroken { get; set; }
    public GameObject floe;
    int floesToBreak;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        floesToBreak = Random.Range(2,3);
        Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(floesToBreak <= numFloesBroken)
        {
            GlobalVars.completedMinigames++;
            SceneManager.LoadScene(sceneName: "mainMap");
        }
    }
}
