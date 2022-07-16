using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failedScan : MonoBehaviour
{
    public GameObject Screen;

    private void OnMouseDown()
    {
        Screen.SetActive(false);
        PersistentManagerScript.Instance.doScanning = true;
    }
}
