using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using UnityEngine.UI;

public class QRCodeReader : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    private bool _isCamAvailible;
    private WebCamTexture _cameraTexture;

    public GameObject sucessScreen;
    public GameObject failScreen;

    //maybe this bool needs to be set to false again for every new scan
    public bool success = false;
    private string QRText;


    void Start()
    {
        //Initialises cam
        SetUpCamera();
        //Makes both screens invisible by default
        sucessScreen.SetActive(false);
        failScreen.SetActive(false);
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
            if (QRText == PersistentManagerScript.Instance.artworkID)
            {
                sucessScreen.SetActive(true);
            }
            else
            {
                failScreen.SetActive(false);
            }
            
        }
    }
    
    //Initialises cam, DO NOT TOUCH
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
                QRText = result.Text;
                //This stops the Scanning one a result has been detected
                success = true;
                
            }
           
        }
        catch
        {
            //do nothing
        }
    }

    //For questions ask Philipp Thalhammer

}
