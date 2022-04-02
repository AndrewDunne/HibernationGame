using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMap : MonoBehaviour
{
    public void returnMapClicked()
    {
        SceneManager.LoadScene(sceneName: "mainMap");
    }
}
