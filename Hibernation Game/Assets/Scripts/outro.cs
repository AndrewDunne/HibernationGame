using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outro : MonoBehaviour
{
    bool ended;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DialogText") == null && !ended)
        {
            ended = true;
            Instantiate(GlobalVars.toWhite, new Vector3(53, 10, 0), Quaternion.identity);
            StartCoroutine(fadeOut(2));
        }
    }
    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName: "credits");
    }
}
