using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteFadeIn : MonoBehaviour
{
    Color opac = new Color(1f, 1f, 1f, 0f);
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = opac;
        opac.a = (Time.timeSinceLevelLoad - startTime) / 4;
        //if (opac.a >= 1)
        //{
        //    DestroyObject(gameObject);
        //}
    }
}
