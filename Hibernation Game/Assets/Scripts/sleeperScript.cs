using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sleeperScript : MonoBehaviour
{
    Vector3 myposition = new Vector3(0f,0f,0f);
    public GameObject pillow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myposition;
    }
    void OnMouseDown()
    {
        //instantiate pillow at mouse
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0.0f;
        Debug.Log("Spawning pillow");
        Instantiate(pillow, spawnPosition, Quaternion.identity);
    }
}
