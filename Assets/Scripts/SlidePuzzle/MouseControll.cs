using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControll : MonoBehaviour, PlayerMove.IPuzzleBoardActions
{
    private PlayerMove inputActions;
    private PlayerMove.PuzzleBoardActions boardActions;

    Vector3 mousePos;
    TileBase hitted;

    //[SerializeField] private GameObject RayCylinder;

    private void Awake()
    {
        inputActions = new PlayerMove();
        boardActions = inputActions.PuzzleBoard;
        boardActions.AddCallbacks(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //RayCylinder.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //RayCylinder.transform.position = mousePos;

        RaycastHit2D hit = Physics2D.Raycast(m_Pos, transform.forward);

        if(hit)
        {
            Debug.Log(hit.transform.tag);
            TileBase tile = null;
            if (hit.transform.tag == "Tile")
            {
                tile = hit.transform.GetComponent<TileBase>();
                tile.PointerEnter();
            }
            if(tile != null && (!hit.transform || hit.transform.tag != "Tile"))
            {
                tile.PointerExit();
                tile = null;
            }
        }
        else
        {
            //Debug.Log(ray.GetPoint(0));
            //ray에 맞은 오브젝트가 직접 ray를 감지할 수 있을까
        }
    }

    public void OnMousePos(InputAction.CallbackContext callbackContext)
    {
        mousePos = callbackContext.ReadValue<Vector2>();
        if(callbackContext.performed)
            Debug.Log(mousePos);
    }

    public void OnMoveTile(InputAction.CallbackContext callbackContext)
    {
        
    }
}
