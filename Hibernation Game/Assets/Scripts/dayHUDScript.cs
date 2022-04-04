using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayHUDScript : MonoBehaviour
{
    public Sprite[] dayImages;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = dayImages[(GlobalVars.day-1)%3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
