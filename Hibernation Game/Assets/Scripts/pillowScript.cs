using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowScript : MonoBehaviour
{
    Color pillowpacity = new Color(1f, 1f, 1f, 1f);
    float spawntime;
    // Start is called before the first frame update
    void Start()
    {
        spawntime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        float opac = 1 - ((Time.timeSinceLevelLoad - spawntime) / 1.4f);
        GetComponent<SpriteRenderer>().color = pillowpacity;
        pillowpacity.a = opac;
        if(pillowpacity.a <= 0)
        {
            DestroyObject(gameObject);
        }
    }
}
