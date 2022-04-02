using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class floeScript : MonoBehaviour
{
    public Sprite newSprite;
    int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            floeGameScript.numFloesBroken++;
            //Destroy(this.gameObject);
            this.GetComponent<SpriteRenderer>().sprite = Circle;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Rekt");
        // this object was clicked - do something
        health--;
    }
}
