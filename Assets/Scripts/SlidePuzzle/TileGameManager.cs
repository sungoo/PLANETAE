using UnityEngine;

public class TileGameManager : MonoBehaviour
{

    [SerializeField] private GameObject tile;

    private bool[][] TileSett;
    private GameObject[,] full_B;
    int tileW;
    int tileH;
    [SerializeField] private float tileOffsetW = 1.5f;
    [SerializeField] private float tileOffsetH = 1.5f;

    private char demoN = 'a';

    // singleton
    public static TileGameManager instance; 
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        TileSetting(3, 1, 6, 2, 1, 3);
        TileInit();
    }

    void Update()
    {
        
    }

    public void TileSetting(int w1 = 10, int wb = 0, int w2 = 0, int h1 = 6, int hb = 0, int h2 = 0)
    {
        int w = w1 + wb + w2;
        int h = h1 + hb + h2;

        bool[] line = new bool[w];
        for(int i = 0; i < w; i++)
        {
            if (i < w1 || i >= w1+wb)
                line[i] = true;
            else
                line[i] = false;
        }
        TileSett = new bool[h][];
        for (int i = 0; i < h; i++)
        {
            if (i < h1 || i >= h1 + wb)
                TileSett[i] = line;
            else
            {
                bool[] tmp = new bool[w];
                for (int j = 0; j < w; j++)
                { tmp[j] = false; }
                TileSett[i] = tmp;
            }
        }
        tileW = w;
        tileH = h;
    }

    private GameObject MakeTile(int h, int w, TileBase.TileType type = TileBase.TileType.Normal, GameObject target_T = null)
    {
        GameObject temp;
        if (target_T == null)
            temp = Instantiate(tile, new Vector3(transform.position.x + tileOffsetW * w, transform.position.y + tileOffsetH * h), Quaternion.identity);
        else
            temp = Instantiate(target_T, new Vector3(transform.position.x + tileOffsetW * w, transform.position.y + tileOffsetH * h), Quaternion.identity);

        TileBase tempTile = temp.GetComponent<TileBase>();
        tempTile.SetLinePos(h, w);
        tempTile.type = type;
        if(type == TileBase.TileType.Normal)
        {
            tempTile.sign = demoN;
            demoN++;
        }
        tempTile.InitTile();

        return temp;
    }

    private void TileInit()
    {
        //테두리 한 칸을 더 씌워서,
        /*
         * 15 11 12 13 14 15 11
         * 5  1  2  3  4  5  1
         * 10 6  7  8  9  10 6
         * 15 11 12 13 14 15 11
         * 5  1  2  3  4  5  1
         */
        //이렇게 만들어지게끔

        //새롭게 쓰는 보드 채우기
        //안쪽 보드
        GameObject[,] inner_B = new GameObject[tileH, tileW];
        //바깥쪽 포함 전체 보드
        full_B = new GameObject[tileH+2, tileW+2];
        //안쪽 채우기
        for(int i =0; i<tileH; i++)
        {
            for(int j =0; j<tileW; j++)
            {
                if(TileSett[i][j])
                    MakeTile(i, j);
                else
                    MakeTile(i, j, TileBase.TileType.Hidden);
            }
        }
        //바깥쪽 채우기
        for(int i = -1, i_real = tileH-1; i<tileH+1; i++, i_real = (i_real+1) % tileH)
        {
            for(int j = -1, j_real = tileW-1; j<tileW+1; j++, j_real =  (j_real+1) % tileW)
            {
                GameObject t_tile = inner_B[i_real, j_real];
                //안쪽 타일이면(i와 i_real 일치), 그대로 집어넣기
                if (i == i_real && j == j_real)
                    full_B[i+1, j+1] = t_tile;
                //i와 i_real 불일치 => 바깥타일. hidden 상태로 생성
                else
                    full_B[i+1, j+1] = MakeTile(i, j, TileBase.TileType.Hidden, tile);
            }
        }

        /*//안쪽 채우기
        GameObject[][] inner_board = new GameObject[tileH][];
        for (int i = 0; i < tileH; i++)
        {
            inner_board[i] = new GameObject[tileW];
            for (int j = 0; j < tileW; j++)
            {
                if (TileSett[i][j])
                {
                    inner_board[i][j] = Instantiate(tile, new Vector3(transform.position.x + tileOffsetW * j, transform.position.y + tileOffsetH * i), Quaternion.identity);
                }
            }
        }
        //테두리 채우기
        board = new GameObject[tileH+2][];
        //가로 0번, 끝번 채우기
        for(int i = 0; i<tileH+2; i++)
        {
            board[i] = new GameObject[tileW+2];
            if (i == 0 || i == tileH + 1)
                continue;
            //해당 줄 마지막 타일이 있는지 확인
            if (inner_board[i-1][tileW-1])
            {
                board[i][0] = Instantiate(inner_board[i-1][tileW - 1], new Vector3(transform.position.x - tileOffsetW, transform.position.y + tileOffsetH * (i-1)), Quaternion.identity);
            }
            for(int j = 0; j<tileW; j++)
                if(inner_board[i - 1][j])
                    board[i][j+1] = inner_board[i - 1][j];
            //해당 줄 첫번째 타일이 있는지 확인
            if (inner_board[i - 1][0])
            {
                board[i][tileW+1] = Instantiate(inner_board[i - 1][0], new Vector3(transform.position.x + tileOffsetW*tileW, transform.position.y + tileOffsetH * (i-1)), Quaternion.identity);
            }
        }
        //상하 0번, 끝번 채우기
        for(int i = 0; i < board[1].Length; i++)
        {
            if(board[board.Length - 2][i])
            {
                board[0][i] = Instantiate(board[board.Length-2][i], new Vector3(transform.position.x + tileOffsetW * (i-1), transform.position.y - tileOffsetH), Quaternion.identity);
            }
            if (board[1][i])
            {
                board[board.Length-1][i] = Instantiate(board[1][i], new Vector3(transform.position.x + tileOffsetW * (i-1), transform.position.y + tileOffsetH*tileH), Quaternion.identity);
            }
        }*/
    }

    void UpdateTileLine()
    {

    }
}
