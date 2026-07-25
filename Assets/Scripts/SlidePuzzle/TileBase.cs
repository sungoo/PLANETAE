using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBase : MonoBehaviour
{
    public delegate void TileDeli(int[] tilePos);
    public event TileDeli TileDeligate;

    public enum TileType
    {
        Normal,
        Fixed,
        Blocked,
        Hidden,
    }

    public char sign = 'a';

    public TileType type;

    private SpriteRenderer spriteRenderer;
    private Color basic_Color;

    private int[] LinePos;
    private bool is_selected = false;
    private bool is_hovered = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InitTile();
    }

    public void SetLinePos(int h, int w)
    {
        LinePos = new int[2];
        LinePos[0] = h;
        LinePos[1] = w;
    }

    public void InitTile()
    {
        switch (type)
        {
            case TileType.Normal:
                basic_Color = Color.white;
                break;
            case TileType.Fixed:
                basic_Color = Color.brown;
                break;
            case TileType.Blocked:
                basic_Color = Color.darkCyan;
                break;
            case TileType.Hidden:
                basic_Color = Color.gray;
                break;
        }
        spriteRenderer.color = basic_Color;
    }

    //타일이 다른 타일 위로 옮겨지면 그 타일의 번호를 습득하며,
    //타일게임 메니져의 라인 업데이트 호출
    //라인 업데이트에선 바뀐 타일의 LinePos를 통해 해당 라인의 타일을 업데이트
    //일단 드래그 보다 선택하고 방향키로 한 칸 씩 이동시키는 걸로 구현해볼것.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PointerEnter();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PointerExit();
    }

    public void PointerEnter()
    {
        Debug.Log("Enter"+LinePos[1]+", " + LinePos[0]+"Letter : "+(int)sign);
        is_hovered = true;
        if(!is_selected)
            spriteRenderer.color = Color.bisque;
    }
    public void PointerExit()
    {
        Debug.Log("Exit");
        is_hovered = false;
        if (!is_selected)
            spriteRenderer.color = basic_Color;
    }
    public void PointerClick()
    {
        if (!is_hovered) return;

        is_selected = !is_selected;
        if (is_selected)
        {
            spriteRenderer.color = Color.orange;
            Debug.Log("Selected");
        }
        else
        {
            spriteRenderer.color = Color.olive;
            Debug.Log("Deselected");
        }
    }
}
