using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArtButton : Button
{
    public new class UxmlFactory : UxmlFactory<ArtButton, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_Text = new UxmlStringAttributeDescription { name = "artID" };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            if (!(ve is ArtButton nse))
                return;

            nse.artID = m_Text.GetValueFromBag(bag, cc);
        }
    }

    [SerializeField]
    private string artID { get; set; }

    public string getArtID()
    {
        return artID;
    }

    public void setArtID(string artID)
    {
        this.artID = artID;
    }
}
