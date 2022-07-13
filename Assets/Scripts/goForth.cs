using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goForth : MonoBehaviour
{
    public GameObject Screen;
    public SceneManagerScript sceneChanger;

    private void OnMouseDown()
    {
        Screen.SetActive(false);
        sceneChanger.goToFifth(PersistentManagerScript.Instance.artworkID);
    }
}
