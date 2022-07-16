using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class ShareButton : MonoBehaviour
{
	private void Awake()
    {
		var root = GetComponent<UIDocument>().rootVisualElement;
		Button shareButton = root.Q<Button>("ShareButton");
		shareButton.RegisterCallback<PointerUpEvent, string>(shareClicked, "dummy");
	}

	private void shareClicked(PointerUpEvent _, string dummy)
	{
		StartCoroutine(TakeScreenshotAndShare());
	}

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("Museum Brandhorst").SetText("Ich habe dieses Kunstwerk entdeckt!").SetUrl("https://www.museum-brandhorst.de/ausstellungen/future-bodies")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();
	}
}
