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
        dialogIndex = 0;
        textMesh.text = dialogs[dialogIndex];
    }

    // Update is called once per frame
    void Update()
    {
        bool old = Time.timeSinceLevelLoad - initializationTime > .5; // player can't advance text for first .5 secs, prevents from missing info
        if (Input.GetMouseButtonDown(0) && old)
        {
            if (dialogIndex < numDialogs - 1)
            {
                dialogIndex++;
                textMesh.text = dialogs[dialogIndex];
                Debug.Log("next");
                //Debug.Log(dialogs[dialogIndex]);
                //Debug.Log(dialogs);
                //Debug.Log(dialogs.Count);
            }
            else
            {
               Debug.Log("Dialog ended");
               Destroy(transform.parent.gameObject);
            }
        }
    }
}
