using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerMove.IFeildMoveActions
{
    private CharacterSprite PlayerSprite;

    private PlayerMove PlayerAction;
    private PlayerMove.FeildMoveActions Player;
    //private CharacterController CharacterController;
    [SerializeField] private float speed = 5f;
    private Vector2 moveVector;
    private bool coll;
    [SerializeField] private Rigidbody2D rigid;

    private void Awake()
    {
        PlayerSprite = GetComponent<CharacterSprite>();
        PlayerAction = new PlayerMove();
        Player = PlayerAction.FeildMove;
        Player.AddCallbacks(this);
        //CharacterController = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnDestroy()
    {
        PlayerAction.Dispose();
    }

    void OnEnable()
    {
        Player.Enable();
    }

    private void OnDisable()
    {
        Player.Disable();
    }

    private void Update()
    {
        //CharacterController.Move(moveVector*Time.deltaTime*speed);
        rigid.AddForce(moveVector, ForceMode2D.Impulse);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (context.performed)
        {
            moveVector = input * speed;
            PlayerSprite.Walking(true);
            if (input.x < 0)
                PlayerSprite.SetDirect(CharacterSprite.Direct.Left);
            else if (input.x > 0)
                PlayerSprite.SetDirect(CharacterSprite.Direct.Right);
            if(input.y < 0)
                PlayerSprite.SetDirect(CharacterSprite.Direct.Front);
            else if (input.y > 0)
                PlayerSprite.SetDirect(CharacterSprite.Direct.Back);
        }
        
        if (context.canceled)
        {
            moveVector = Vector2.zero;
            PlayerSprite.Walking(false);
        }
    }
    public void OnInterect(InputAction.CallbackContext context)
    {
        Debug.Log("Interect");
    }
}
