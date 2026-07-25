using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControll : MonoBehaviour, PlayerMove.IPuzzleBoardActions
{
    private PlayerMove inputActions;
    private PlayerMove.PuzzleBoardActions boardActions;

    Vector3 mousePos;
    [SerializeField] GameObject rayCircle;

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

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rayCircle.transform.position = m_Pos;
    }

    public void OnMousePos(InputAction.CallbackContext callbackContext)
    {
        
    }

    public void OnMoveTile(InputAction.CallbackContext callbackContext)
    {
        
    }
}
