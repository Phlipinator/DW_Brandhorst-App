using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HideStart : MonoBehaviour
{

    public GameObject startScreen;

    private void OnMouseDown()
    {
        startScreen.SetActive(false);
    }
}
