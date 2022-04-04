using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sleeperGameScript : MonoBehaviour
{
    string[] gemNames = new string[] { "Jade", "Rutile", "Bortz", "Diamond" };
    static bool[] visited = new bool[] { false, false, false, false }; // Will this stay the same even if scene is reloaded?
    public GameObject[] gemTexts;
    public GameObject[] areaTexts;
    public GameObject[] gems;
    bool pillowThrown;
    int currentGem;
    int currentRoom; // Room 0 is main corridor, 1 is medical area, 2 is dormitories
    // Start is called before the first frame update
    int gemRoom; // Room that sleeper is in
    public Sprite[] backgrounds;
    public GameObject LRButtons;
    bool gameStarted;
    bool clickable;
    bool gameOver;
    Color transparent = new Color(1f, 1f, 1f, 0f);
    Color opaque = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        currentGem = 0;
        currentGem = Random.Range(0, 4);
        while (visited[currentGem])
        {
            currentGem = Random.Range(0, 4);
        }
        visited[currentGem] = true;
        currentRoom = Random.Range(0, 3);
        GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgrounds[currentRoom];
        gemRoom = Random.Range(0, 3);
        while (gemRoom == currentRoom)
        {
            gemRoom = Random.Range(0, 3);
        }
        Debug.Log("Gem#: " + currentGem);
        Debug.Log("Gem name: " + gemNames[currentGem]);
        Debug.Log("Current room: " + currentRoom);
        Debug.Log("Gem room: " + gemRoom);
        gameStarted = false;
        pillowThrown = false;
        clickable = false;
        gameOver = false;
        GameObject.Find("leftButton").GetComponent<Image>().color = transparent;
        GameObject.Find("RightButton").GetComponent<Image>().color = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogBox") == null && !gameStarted) // Entry dialog done
        {
            //myFloe = Instantiate(floe, new Vector3(0, 0, 0), Quaternion.identity);
            //myTimer = Instantiate(timer, new Vector3(0, 7.5f, 0), Quaternion.identity);
            gameStarted = true;
            clickable = true;
            GameObject.Find("leftButton").GetComponent<Image>().color = opaque;
            GameObject.Find("RightButton").GetComponent<Image>().color = opaque;
            //Instantiate(LRButtons, new Vector3(430f, 210f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            //startTime = Time.timeSinceLevelLoad;
        }
        if (GameObject.Find("Pillow(Clone)") != null && pillowThrown == false) // Pillow mid-travel
        {
            pillowThrown = true;
            clickable = false;
        }
        if (pillowThrown && GameObject.Find("Pillow(Clone)") == null && !gameOver) // Pillow hit and disappeared along with character
        {
            GameObject.Find("leftButton").GetComponent<Image>().color = transparent;
            GameObject.Find("RightButton").GetComponent<Image>().color = transparent;
            Instantiate(gemTexts[currentGem], new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            gameOver = true;
        }
        if (gameOver && GameObject.Find(gemTexts[currentGem].name + "(Clone)") == null)
        {
            //Debug.Log(gemTexts[currentGem] + "(Clone)");
            SceneManager.LoadScene(sceneName: "mainMap");
        }
    }
    public void goLeft()
    {
        if (clickable)
        {
            currentRoom = currentRoom - 1;
            if (currentRoom == -1)
            {
                currentRoom = 2;
            }
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgrounds[currentRoom];
            if (currentRoom == gemRoom)
            {
                // spawn sleeper. when pillow dies, that's when gamemanager knows when to start the end dialog
                Instantiate(gems[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
                Debug.Log("Spawning sleeper");
            }
            else
            {
                if (GameObject.Find(gems[0].name + "(Clone)") != null)
                {
                    Destroy(GameObject.Find(gems[0].name + "(Clone)"));
                    Debug.Log("Despawning sleeper");
                }
            }
        }
    }
    public void goRight()
    {
        if (clickable)
        {
            currentRoom = (currentRoom + 1) % 3;
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgrounds[currentRoom];

            if (currentRoom == gemRoom)
            {
                // spawn sleeper. when pillow dies, that's when gamemanager knows when to start the end dialog
                Instantiate(gems[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
                //Debug.Log("Spawning sleeper");
            }
            else
            {
                if (GameObject.Find(gems[0].name + "(Clone)") != null)
                {
                    Destroy(GameObject.Find(gems[0].name + "(Clone)"));
                    //Debug.Log("Despawning sleeper");
                }
            }
        }
    }
}
