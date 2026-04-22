using UnityEngine;

public class BackGround : MonoBehaviour
{
    public string name;
    [SerializeField] private Texture2D image;

    [Header("Texture Offset")]
    public float x = 0;
    public float y = 0;
    public float width = 1;
    public float height = 1.91f;

    private Rect uv;

    private void Start()
    {
        uv = new Rect(x, y, width, height);
    }

    public Texture2D GetTexture() { return image; }
    public Rect GetUV() { return uv; }
}
