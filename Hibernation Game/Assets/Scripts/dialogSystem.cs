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
    public int numDialogs;
    bool textInit;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        initializationTime = Time.timeSinceLevelLoad;
        textInit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dialogs.Count);
        bool old = Time.timeSinceLevelLoad - initializationTime > .5; // player can't advance text for first .5 secs, prevents from missing info
        if (dialogs.Count > 0 && !textInit)
        {
            textMesh.text = dialogs[dialogIndex];
            textInit = true;
            Debug.Log("Dialog count at init: " + dialogs.Count);
        }
        if (Input.GetMouseButtonDown(0) && old && textInit)
        {
            if (dialogIndex < numDialogs - 1)
            {
                dialogIndex++;
                textMesh.text = dialogs[dialogIndex];
                Debug.Log("next");
                Debug.Log(dialogs[dialogIndex]);
                Debug.Log(dialogs);
                Debug.Log(dialogs.Count);
            }
            else
            {
               Debug.Log("Dialog ended");
               Destroy(transform.parent.gameObject);
            }
        }
    }
}
