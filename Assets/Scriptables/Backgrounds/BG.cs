using UnityEngine;

[CreateAssetMenu(fileName = "BG", menuName = "Scriptable Objects/BG")]
public class BG : ScriptableObject
{
    public string name;
    [SerializeField] private Texture2D image;

    [Header("Texture Offset")]
    public Rect uv;

    public Texture2D GetTexture() { return image; }
    public Rect GetUV() { return uv; }
}
