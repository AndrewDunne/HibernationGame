using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class floeScript : MonoBehaviour
{
    public Sprite invisSprite;
    public Sprite floeSprite;
    bool canClick;
    int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi");
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            floeGameScript.numFloesBroken++;
            canClick = false;
            health = 5;
            //Destroy(this.gameObject);
            this.GetComponent<SpriteRenderer>().sprite = invisSprite;
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    void OnMouseDown()
    {
        if (canClick == true) { 
            //Debug.Log("Rekt");
            // this object was clicked - do something
            health--;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<SpriteRenderer>().sprite = floeSprite;
        canClick = true;
    }
}
