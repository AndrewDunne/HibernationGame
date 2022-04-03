using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleeperGameScript : MonoBehaviour
{
    string[] gemNames = new string[] { "Jade", "Rutile", "Bortz", "Diamond" };
    bool[] visited = new bool[] { true, false, false, false, false }; // Will this stay the same even if scene is reloaded?
    int currentGem;
    int currentRoom; // Room 0 is main corridor, 1 is medical area, 2 is dormitories
    // Start is called before the first frame update
    public Sprite[] backgrounds;
    public GameObject LRButtons;
    bool gameStarted;
    Color transparent = new Color(1f, 1f, 1f, 0f);
    Color opaque = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        currentGem = 0;
        while (visited[currentGem])
        {
            currentGem = Random.Range(1, 4);
        }
        Debug.Log(currentGem);
        Debug.Log(gemNames[currentGem-1]);
        gameStarted = false;
        GameObject.Find("leftButton").GetComponent<Image>().color = transparent;
        GameObject.Find("RightButton").GetComponent<Image>().color = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted)
        {
            //myFloe = Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
            //myTimer = Instantiate(timer, new Vector3(0, 7.5f, 0), Quaternion.identity);
            gameStarted = true;
            GameObject.Find("leftButton").GetComponent<Image>().color = opaque;
            GameObject.Find("RightButton").GetComponent<Image>().color = opaque;
            //Instantiate(LRButtons, new Vector3(430f, 210f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            //startTime = Time.timeSinceLevelLoad;
        }
    }
    public void goLeft()
    {
        currentRoom = currentRoom - 1;
        if(currentRoom == -1)
        {
            currentRoom = 2;
        }
        GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgrounds[currentRoom];
    }
    public void goRight()
    {
        currentRoom = (currentRoom + 1) % 3;
        GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgrounds[currentRoom];
    }
}
