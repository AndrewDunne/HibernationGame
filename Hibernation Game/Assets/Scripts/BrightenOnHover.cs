using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightenOnHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(2, 2, 2, 1);
    }
}
