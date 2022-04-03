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
    private float initializationTime;
    int updates;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        initializationTime = Time.timeSinceLevelLoad;
        updates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updates++;
        bool old = Time.timeSinceLevelLoad - initializationTime > .5;
        if (updates == 5)
        {
            textMesh.text = dialogs[dialogIndex];
        }
        if (Input.GetMouseButtonDown(0) && old)
        {
            if (dialogIndex < dialogs.Count - 1)
            {
                dialogIndex++;
                textMesh.text = dialogs[dialogIndex];
            }
            else
            {
                // Call some function here before self destructing 
               Debug.Log("Dialog ended");
               Destroy(transform.parent.gameObject);
            }
        }
    }
}
