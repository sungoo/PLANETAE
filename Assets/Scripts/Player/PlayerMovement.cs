using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerMove.IFeildMoveActions
{
    private PlayerMove PlayerAction;
    private PlayerMove.FeildMoveActions Player;

    private void Awake()
    {
        PlayerAction = new PlayerMove();
        Player = PlayerAction.FeildMove;
        Player.AddCallbacks(this);
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

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Debug.Log(input);
    }
    public void OnInterect(InputAction.CallbackContext context)
    {
        Debug.Log("Interect");
    }
}
