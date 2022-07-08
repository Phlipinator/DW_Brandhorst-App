using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failedScan : MonoBehaviour
{
    public GameObject button;

    public void backtoScanning()
    {
        button.SetActive(false);
    }
}
