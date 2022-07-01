using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;

public class QRCodeReader : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;
    [SerializeField]
    private TextMeshProUGUI _textOut;

    private bool _isCamAvailible;
    private WebCamTexture _cameraTexture;

    public GameObject Screen;
    private bool success = false;


    void Start()
    {
        SetUpCamera();
        Screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraRender();

        //Only does Scans when there is not a result
        if (!success)
        {
            Scan();
        }
        else
        {
            //In this switch case the handling for all diffrent QR-Codes will be done
            switch (_textOut.text)
            {
                case "Test1":
                    Debug.Log("Hallo das ist Test1");
                    break;
                case "Test2":
                    Debug.Log("Hallo das ist Test2");
                    break;
            }
            
        }
    }
    //This Method can be called when you want to resume scanning
    public void BackToScan()
    {
        success = false;
        Screen.SetActive(false);

    }

    private void SetUpCamera()
    {
        _cameraTexture = new WebCamTexture();
        _cameraTexture.Play();
        _rawImageBackground.texture = _cameraTexture;
        _isCamAvailible = true;
    }

    //Fixes warping issues
    private void UpdateCameraRender()
    {
        if (_isCamAvailible == false)
        {
            return;
        }
        float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;
        _aspectRatioFitter.aspectRatio = ratio;

        int orientation = -_cameraTexture.videoRotationAngle;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    //Handels the QR-Code Scanning 
    //DO NOT TOUCH!
    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameraTexture.GetPixels32(), _cameraTexture.width, _cameraTexture.height);
            if (result != null)
            {
                _textOut.text = result.Text;
                //This stops the Scanning one a result has been detected
                Screen.SetActive(true);
                success = true;
                
            }
           
        }
        catch
        {
            _textOut.text = "FAILED TRY";
        }
    }
    
}
