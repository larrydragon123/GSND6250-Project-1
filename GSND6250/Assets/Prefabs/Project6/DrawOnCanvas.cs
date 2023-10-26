using UnityEngine;
using UnityEngine.UI;

public class DrawOnCanvas : MonoBehaviour
{
    public RawImage canvasImage;
    public Texture2D canvasTexture;
    public Color drawingColor = Color.black;
    public float brushSize = 10f;

    private Vector2? previousPosition;

    void Start()
    {
        // Initialize the canvas texture
        canvasTexture = new Texture2D(512, 512);
        canvasTexture.filterMode = FilterMode.Point; // For pixel art-style drawing
        canvasImage.texture = canvasTexture;
    }

    void Update()
    {
        // Check for user input (e.g., mouse click and drag)
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;

            if (previousPosition.HasValue)
            {
                // Draw a line from the previous position to the current position
                DrawLine(previousPosition.Value, mousePosition);
            }

            previousPosition = mousePosition;
        }
        else
        {
            previousPosition = null;
        }
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        int width = canvasTexture.width;
        int height = canvasTexture.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Vector2.Distance(new Vector2(x, y), start) < brushSize)
                {
                    canvasTexture.SetPixel(x, y, drawingColor);
                }
            }
        }

        canvasTexture.Apply(); // Apply the changes to the texture
    }
}
