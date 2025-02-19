using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private SpriteRenderer headRenderer;
    [SerializeField] private SpriteRenderer clothesRenderer;
    private Transform headPivot;
    private Transform clothesPivot;


    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected bool isLeft = false;

    protected AnimationHandler[] animationHandlers;





    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandlers = GetComponentsInChildren<AnimationHandler>();
        clothesPivot = transform.Find("ClothesPivot");
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        SetIsLeft();
        Rotate(isLeft);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        

        _rigidbody.velocity = direction;
        foreach (var handler in animationHandlers) 
        handler.Move(direction);
    }

    private void Rotate(bool _isLeft)
    {
        characterRenderer.flipX = _isLeft;
        if(headRenderer != null)
            headRenderer.flipX = _isLeft;

        if (clothesRenderer != null)
            clothesRenderer.flipX = _isLeft;

        if (clothesPivot != null)
            RotatePivot(clothesPivot, _isLeft);

        if (headPivot != null)
            RotatePivot(headPivot, _isLeft);
    }

    private void RotatePivot(Transform pivot,bool _isLeft)//피벗의 로컬포지션x 반전
    {
        Vector3 localPos = pivot.localPosition;
        if (_isLeft && pivot.localPosition.x > 0)
        {
            localPos.x = -localPos.x;
            pivot.localPosition = localPos;
        }
        else if(!_isLeft && pivot.localPosition.x < 0)
        {
            localPos.x = -localPos.x;
            pivot.localPosition = localPos;
        }
    }

    protected virtual void SetIsLeft() { }
}
