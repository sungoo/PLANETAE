using UnityEngine;

public class TileBase : MonoBehaviour
{
    public enum TileType
    {
        Normal,
        Fixed,
        Blocked,
    }

    public char sign = 'a';

    public TileType type;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
