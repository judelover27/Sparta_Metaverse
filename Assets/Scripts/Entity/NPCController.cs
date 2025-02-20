using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BaseController
{
    [SerializeField] private float moveSpeed = 2f;
    float moveDirection;
    protected override void SetIsLeft()
    {
        if (_rigidbody.velocity.x < 0)
            isLeft = true;
        else
            isLeft = false;
    }

    private void RandomMove()
    {
        Debug.Log("RandomMove activated");

        if(transform.position.x > 10f)
            moveDirection = Random.Range(-8f, 0);
        else if(transform.position.x < 6f)
            moveDirection = Random.Range(0, 8f);
        else
            moveDirection = Random.Range(-8f, 8f);

        if (Mathf.Abs(moveDirection) < moveSpeed)
            moveDirection = 0;


            _rigidbody.velocity = new Vector2(moveDirection,0).normalized*moveSpeed;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            RandomMove();
            yield return new WaitForSeconds(Random.Range(1f,2f));
        }
    }

    protected override void FixedUpdate()
    {

    }

}
