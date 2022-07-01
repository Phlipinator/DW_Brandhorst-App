using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStart : MonoBehaviour
{
    public GameObject startScreen;

    private void OnMouseDown()
    {
        startScreen.SetActive(true);
    }
}
