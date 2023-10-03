using UnityEngine;

namespace Blogs
{
    public class LevelGenerator : MonoBehaviour
    {
        public Texture2D GameMap;
        public ColorToObject[] ColorMapping;
        private Color _colorPixel;

        void Start()
        {
            CreateLevels();
        }
      



        void CreateLevels()
        {
            //Scan the with & height of the given map to find the position of the game object.
            for (int i = 0; i < GameMap.width; i++)
            {
                for (int j = 0; j < GameMap.height; j++)
                {
                    GenerateObject(i, j);
                }
            }
        }



        void GenerateObject(int xPos, int yPos)
        {
            // gets the pixel color
            _colorPixel = GameMap.GetPixel(xPos, yPos);
            //Condition: if the alpha value of the given color is zero then do nothing;
            if (_colorPixel.a == 0) return;


            foreach (ColorToObject colorMapping in ColorMapping)
            {
                // Scan color mapping Array for matching color mapping
                if (colorMapping.ObjectColor.Equals(_colorPixel))
                {
                    Vector2 position = new Vector2(xPos, yPos);
                    Instantiate(colorMapping.GamePrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }
}