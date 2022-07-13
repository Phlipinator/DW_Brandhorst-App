using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack : MonoBehaviour
{
    public GameObject Screen;
    public SceneManagerScript sceneChanger;

    private void OnMouseDown()
    {
        Screen.SetActive(false);
        sceneChanger.goBack();
    }
}
