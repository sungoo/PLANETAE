using UnityEngine;

public class Tools : MonoBehaviour
{
    private Vector2 firstPos;
    private Vector2 mousePos;
    [SerializeField]
    private Vector2 mouseOffset;
    [SerializeField]
    private Vector3 clickRotation;
    [SerializeField]
    private Vector3 returnRotation;

    private Vector2 pickMeMove;
    private float moveVelue = 0.5f;

    private bool mouseClicked = false;
    private static bool mouseHoldingSomething = false;

    [SerializeField]
    private GameObject ReturnBtn;

    private SpriteRenderer SpriteRenderer;
    private BoxCollider2D BoxCollider2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        firstPos = transform.position;
        pickMeMove = new Vector2(firstPos.x, firstPos.y+moveVelue);
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouseClicked)
            return;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos + mouseOffset;
    }

    public void MouseHold()
    {
        if (mouseClicked || mouseHoldingSomething)
            return;
        transform.position = pickMeMove;
        Debug.Log("Enter");
    }
    public void MouseOut()
    {
        if (mouseClicked || mouseHoldingSomething)
            return;
        transform.position = firstPos;
        Debug.Log("Exit");
    }

    public void MouseClicked()
    {
        if (mouseHoldingSomething)
            return;
        mouseClicked = true;
        mouseHoldingSomething=true;
        ReturnBtn.SetActive(true);

        BoxCollider2D.enabled = false;
        transform.Rotate(clickRotation);
        SpriteRenderer.sortingLayerName = "Character";
    }
    public void ReturnBtnClicked()
    {
        mouseClicked=false;
        mouseHoldingSomething=false;
        ReturnBtn.SetActive(false);
        transform.position = firstPos;

        BoxCollider2D.enabled = true;
        transform.Rotate(returnRotation);
        SpriteRenderer.sortingLayerName = "Prop";
    }
}
