using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogSystem : MonoBehaviour
{
    public string[] names;// = new string[] { "Matt", "Joanne", "Robert" };
    int dialogIndex;
    bool mouseDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (mouseDown == false)
            {
                Debug.Log("Pressed left click.");
                mouseDown = true;
            }
            
        }
        else
        {
            mouseDown = false;
            Debug.Log("Released left click.");
        }
    }
}
