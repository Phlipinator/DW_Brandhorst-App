using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QRCodeReader : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    private bool _isCamAvailible;
    //private WebCamTexture _cameraTexture;

    public GameObject failScreen;
    public GameObject sucessScreen;
    public SceneManagerScript sceneChanger;

    private string QRText;
    void Start()
    {
        //uncomment to test without scanning
        //PersistentManagerScript.Instance.unlockedArtworks.Add(PersistentManagerScript.Instance.artworkID);
        //sceneChanger.goToFifth(PersistentManagerScript.Instance.artworkID);

        //Initialises cam
        SetUpCamera();
        //Makes both screens invisible by default
        failScreen.SetActive(false);
        sucessScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraRender();

        //Only does Scans when there is not a result
        if (PersistentManagerScript.Instance.doScanning)
        {
            Scan();
        }
        else
        {
            if (QRText == "art" + PersistentManagerScript.Instance.artworkID.ToString())
            {
                //Adds the unlocked Artwork to a List
                PersistentManagerScript.Instance.unlockedArtworks.Add(PersistentManagerScript.Instance.artworkID);
                PersistentManagerScript.Instance._cameraTexture.Stop();
                // or goToSixt, if we want to show Tropy overview
                //sceneChanger.goToFifth(PersistentManagerScript.Instance.artworkID);
                sucessScreen.SetActive(true);
            }
            else
            {   
                //doScanning gets set to true by clicking the pop-up
                failScreen.SetActive(true);
                
            }
            
        }
    }
    
    //Initialises cam, DO NOT TOUCH
    private void SetUpCamera()
    {
        PersistentManagerScript.Instance._cameraTexture = new WebCamTexture();
        PersistentManagerScript.Instance._cameraTexture.Play();
        _rawImageBackground.texture = PersistentManagerScript.Instance._cameraTexture;
        _isCamAvailible = true;
    }

    //Fixes warping issues
    private void UpdateCameraRender()
    {
        if (_isCamAvailible == false)
        {
            return;
        }
        float ratio = (float)PersistentManagerScript.Instance._cameraTexture.width / (float)PersistentManagerScript.Instance._cameraTexture.height;
        _aspectRatioFitter.aspectRatio = ratio;

        int orientation = -PersistentManagerScript.Instance._cameraTexture.videoRotationAngle;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    //Handels the QR-Code Scanning 
    //DO NOT TOUCH!
    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(PersistentManagerScript.Instance._cameraTexture.GetPixels32(), PersistentManagerScript.Instance._cameraTexture.width, PersistentManagerScript.Instance._cameraTexture.height);
            if (result != null)
            {
                QRText = result.Text;
                //This stops the Scanning one a result has been detected
                PersistentManagerScript.Instance.doScanning = false;
                result = null;
            }
           
        }
        catch
        {
            //do nothing
        }
    }

    //For questions ask Philipp Thalhammer

}
