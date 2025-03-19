using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image imageComponent; 
    public Sprite newSprite; 

    void Start()
    {
        if (imageComponent != null && newSprite != null)
        {
            imageComponent.sprite = newSprite;
        }
    }
}

