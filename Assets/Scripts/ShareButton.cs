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

		int artID = PersistentManagerScript.Instance.artworkID;
		Art art = PersistentManagerScript.Instance.getArtByID(artID);
		Texture2D sprite = Resources.Load<Texture2D>("Sprites/largeImages/" + artID.ToString());
		if (sprite == null)
        {
			sprite = Resources.Load<Texture2D>("Sprites/thumbnails/" + artID.ToString());
		}		
		new NativeShare().AddFile(sprite, "artwork.png")
			.SetSubject("Hey, ich habe dieses Kunstwerk in der neuen App des Museum Brandhorst gefunden!").SetText(art.getDescription()).SetUrl("https://www.museum-brandhorst.de/ausstellungen/future-bodies")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();
	}
}
