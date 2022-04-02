using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floeGameScript : MonoBehaviour
{
    public static int numFloesBroken { get; set; }
    int floesToBreak;
    // Start is called before the first frame update
    void Start()
    {
        numFloesBroken = 0;
        floesToBreak = Random.Range(2,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(floesToBreak <= numFloesBroken)
        {
            SceneManager.LoadScene(sceneName: "mainMap");
        }
    }
}
