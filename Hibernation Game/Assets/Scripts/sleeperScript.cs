using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sleeperScript : MonoBehaviour
{
    public float sleeperPeriod;
    public float sleeperSpeed;
    Vector3 myposition = new Vector3(0f,0f,0f);
    public GameObject pillow;
    bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        myposition = new Vector3(Mathf.Sin(Time.timeSinceLevelLoad / sleeperPeriod)*sleeperSpeed, 0f, 0f); 
        transform.position = myposition;
        if (clicked == true && GameObject.Find("Pillow(Clone)") == null)
        {
            Debug.Log("Self destructing");
            DestroyObject(gameObject);
        }
    }
    void OnMouseDown()
    {
        //instantiate pillow at mouse
        if (clicked == false)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            Debug.Log("Spawning pillow");
            Instantiate(pillow, spawnPosition, Quaternion.identity);
            clicked = true;
        }
    }
}
