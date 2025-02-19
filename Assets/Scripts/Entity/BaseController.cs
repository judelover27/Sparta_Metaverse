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
    [SerializeField] private Transform headPivot;

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

    }

    protected virtual void SetIsLeft() { }
}
