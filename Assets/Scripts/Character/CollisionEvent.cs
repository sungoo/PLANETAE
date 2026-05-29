using Unity.Mathematics;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField]
    CharacterSprite animate;

    private void Awake()
    {
        animate = GetComponentInParent<CharacterSprite>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        Debug.Log("collision");
        Vector2 dist = transform.position - other.transform.position;

        if (math.abs(dist.x) > math.abs(dist.y))
        {
            //좌 우
            if (dist.x > 0)
                animate.SetDirect(CharacterSprite.Direct.Left);
            else
                animate.SetDirect(CharacterSprite.Direct.Right);
        }
        else
        {
            //상 하
            if (dist.y > 0)
                animate.SetDirect(CharacterSprite.Direct.Front);
            else
                animate.SetDirect(CharacterSprite.Direct.Back);
        }
    }
}
