using UnityEngine;

public class PixelColorChecker : MonoBehaviour
{
    public Texture2D mapTexture;
    public Color objectColor;
    public GameObject prefab;

    void Start()
    {
        ReadPixelColors();
    }

    void ReadPixelColors()
    {
        for (int x = 0; x < mapTexture.width; x++)
        {
            for (int y = 0; y < mapTexture.height; y++)
            {
                Color32 pixelColor = mapTexture.GetPixel(x, y);
                if (pixelColor == objectColor)
                {
                    Debug.Log("Pixel at position (" + x + ", " + y + ") has color: " + pixelColor);
                    Vector2 pos = new Vector2(x, y);
                    Instantiate(prefab, pos, Quaternion.identity, transform);

                }
            }
        }
    }
}
