using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVars.day == 0)
        {
            GlobalVars.day = 1;
        }
        Debug.Log(GlobalVars.day);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class GlobalVars
{
    public static int day { get; set; }
    public static float timeOfDay { get; set; }
    public static int completedMinigames { get; set; }
}
