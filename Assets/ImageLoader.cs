using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image imageComponent; // Drag your Image component here
    public Sprite newSprite; // Drag your new Sprite here in the Inspector

    void Start()
    {
        if (imageComponent != null && newSprite != null)
        {
            imageComponent.sprite = newSprite;
        }
    }
}

