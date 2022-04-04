using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayManager : MonoBehaviour
{
    public GameObject white;
    public Sprite[] antarcEmotes;
    // Start is called before the first frame update
    void Start()
    {
        GlobalVars.toWhite = white;
        GlobalVars.Emotes = antarcEmotes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class GlobalVars
{
    public static int day { get; set; }
    public static float timeLeft { get; set; }
    public static int completedMinigames { get; set; }
    public static bool floeDone { get; set; }
    public static bool sleepDone { get; set; }
    public static bool eventDone { get; set; }
    public static bool intro { get; set; }
    public static GameObject toWhite { get; set; }
    public static Sprite[] Emotes { get; set; }
}
