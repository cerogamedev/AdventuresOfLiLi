using UnityEngine;

public class PixelColorChecker : MonoBehaviour
{
    private static PixelColorChecker instance;
    public static PixelColorChecker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PixelColorChecker>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("PixelColorChecker");
                    instance = singletonObject.AddComponent<PixelColorChecker>();
                }
            }
            return instance;
        }
    }

    public Texture2D mapTexture;
    public Color[] objectColor;
    public GameObject[] prefab;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        ReadPixelColors();
    }

    private void ReadPixelColors()
    {
        for (int x = 0; x < mapTexture.width; x++)
        {
            for (int y = 0; y < mapTexture.height; y++)
            {
                Color32 pixelColor = mapTexture.GetPixel(x, y);
                for (int i = 0; i < objectColor.Length; i++)
                {
                    if (pixelColor == objectColor[i])
                    {
                        Vector2 pos = new Vector2(x, y);
                        Instantiate(prefab[i], pos, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}
