using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    public enum Direct
    {
        Front,
        Back,
        Left,
        Right
    }

    public Direct PlayerDirct;
    private bool isWalking = false;

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.SetInteger("Direction", 0);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsWalk", isWalking);
        _animator.SetInteger("Direction", (int)PlayerDirct);
    }

    public void Walking(bool walk)
    {
        isWalking = walk;
    }

    public void SetDirect(Direct direct)
    {
        PlayerDirct = direct;
    }

    
}
