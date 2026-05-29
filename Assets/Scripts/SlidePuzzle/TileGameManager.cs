using UnityEngine;

public class TileGameManager : MonoBehaviour
{
    [SerializeField] private GameObject tile;

    private bool[][] TileSett;
    private GameObject[][] board;
    int tileW;
    int tileH;
    [SerializeField] private float tileOffsetW = 1.5f;
    [SerializeField] private float tileOffsetH = 1.5f;

    void Start()
    {
        TileSetting();
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

    private void TileInit()
    {
        board = new GameObject[tileH][];
        for(int i = 0; i<tileH; i++)
        {
            board[i] = new GameObject[tileW];
            for(int j = 0;j<tileW; j++)
            {
                board[i][j] = Instantiate(tile, new Vector3(transform.position.x + tileOffsetW*j, transform.position.y + tileOffsetH*i), Quaternion.identity);
            }
        }
    }
}
