using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowScript : MonoBehaviour
{
    Color pillowpacity = new Color(1f, 1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = pillowpacity;
        pillowpacity.a -= .01f;
        if(pillowpacity.a <= 0)
        {
            DestroyObject(gameObject);
        }
    }
}
