using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogSystem : MonoBehaviour
{
    public List<string> dialogs;
    int dialogIndex;
    private TextMeshProUGUI textMesh;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = dialogs[dialogIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogIndex < dialogs.Count - 1)
            {
                dialogIndex++;
                textMesh.text = dialogs[dialogIndex];
            }
            else
            {
               // Call some function here before self destructing 
               
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
