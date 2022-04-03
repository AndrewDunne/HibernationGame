using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class floeScript : MonoBehaviour
{
    public Sprite invisSprite;
    public Sprite floeSprite;
    public AudioClip clink;
    public AudioClip crash;
    public AudioClip shatter;
    bool canClick;
    int health = 15;
    AudioSource SFX;
    Vector3 weakSpotLoc;

    // Start is called before the first frame update
    void Start()
    {
        canClick = true;
        SFX = GetComponent<AudioSource>();
        weakSpotLoc.x = UnityEngine.Random.Range(214.0f, 660.0f);
        weakSpotLoc.y = UnityEngine.Random.Range(10.0f, 470.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            floeGameScript.numFloesBroken++;
            canClick = false;
            health = 15;
            this.GetComponent<SpriteRenderer>().sprite = invisSprite;
            weakSpotLoc.x = UnityEngine.Random.Range(214.0f, 660.0f);
            weakSpotLoc.y = UnityEngine.Random.Range(10.0f, 470.0f);
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    void OnMouseDown()
    {
        if (canClick == true) {
            // this object was clicked - do something
            Vector3 mousePos = Input.mousePosition;
            //Debug.Log(mousePos.x);
            //Debug.Log(mousePos.y);
            float distance = MathF.Sqrt(MathF.Pow(mousePos.x - weakSpotLoc.x,2) + MathF.Pow(mousePos.y - weakSpotLoc.y,2));
            //Debug.Log(distance);
            float myPitch = (float)(.2 / MathF.Log((distance / 2000.0f) + 1.05f));
            SFX.pitch = myPitch;
            if(distance < 50)
            {
                SFX.pitch = 0.65F;
                SFX.PlayOneShot(crash, .6F);
                SFX.PlayOneShot(shatter, .6F);
                health = 0;
            }
            else
            {
                SFX.PlayOneShot(clink, myPitch/6);
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<SpriteRenderer>().sprite = floeSprite;
        canClick = true;
    }
}
