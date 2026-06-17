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

    private int[] LinePos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void SetLinePos(int v, int h)
    {
        LinePos = new int[2];
        LinePos[0] = v;
        LinePos[1] = h;
    }

    //타일이 다른 타일 위로 옮겨지면 그 타일의 번호를 습득하며,
    //타일게임 메니져의 라인 업데이트 호출
    //라인 업데이트에선 바뀐 타일의 LinePos를 통해 해당 라인의 타일을 업데이트
    //일단 드래그 보다 선택하고 방향키로 한 칸 씩 이동시키는 걸로 구현해볼것.
}
