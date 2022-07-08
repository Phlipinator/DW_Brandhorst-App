using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failedScan : MonoBehaviour
{

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        PersistentManagerScript.Instance.doScanning = true;
    }
}
