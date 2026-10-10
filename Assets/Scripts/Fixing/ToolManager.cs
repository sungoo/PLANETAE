using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public enum MouseState
    {
        None,
        Driver,
        Pinch,
        Tower,
        WD,
        Buster,
    }
    public MouseState NowHolding = MouseState.None;

    public static ToolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeTool(MouseState state)
    {
        NowHolding = state;
    }

    public bool IsHandFree()
    {
        if (NowHolding == MouseState.None)
            return true;
        else
            return false;
    }
}
