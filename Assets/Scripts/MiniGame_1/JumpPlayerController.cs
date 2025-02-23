using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask CollisionLayer;
    private Camera _camera;
    private Vector2 lookDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private LineRenderer lineRenderer;

    private float power = 1f;
    public float chargeSpeed = 5f; // power 증가 속도 (초당)
    public float maxPower = 10f;  // 최대 power 값
    public float Power {  get { return power; } }

    private bool isDead = true;
    public bool IsDead { get { return isDead; } set { isDead = value; } }


    private void Awake()
    {
        _camera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isDead) return;

        MouseDirection();
        DrawMouseDirection();
        MouseClickPower();
    }
    private void MouseDirection()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);//마우스의 좌표는 해상도 좌표이다 이것을월드좌표로 변환
        lookDirection = (worldPos - (Vector2)transform.position).normalized;//transform.position 의 타입은 Vector3이므로 캐스팅 필요

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg;//atan2를 이용해 디그리로 변환 주의점 Atant2(y,x)이다.

        angle = Mathf.Clamp(angle, 0, 90);//0,90 도 사이로 제한
        float rad = angle * Mathf.Deg2Rad;//다시 라디안
        lookDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;//사인 코사인을 통해 원상복구
    }

    private void MouseClickPower()
    {
        if (_rigidbody.velocity == Vector2.zero)
        {
            if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼을 누르고 있으면
            {
                power += chargeSpeed * Time.deltaTime; // power 증가
                power = Mathf.Min(power, maxPower); // 최대값 제한
            }
            else if (Input.GetMouseButtonUp(0)) // 마우스 버튼을 떼면 power 초기화
            {
                Jump(lookDirection, power);
                power = 1f;
            }
        }
    }

    public void Jump(Vector2 direction, float _power)
    {
        Vector2 velocity = direction * _power;
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionLayer.value == (CollisionLayer.value | 1 >> collision.gameObject.layer))
        {

            isDead = true;
            MiniGameUIManager_1.Instance.UpdateBestScore();
            MiniGameUIManager_1.Instance.SetScoreUI();
            MiniGameUIManager_1.Instance.ChangeState(UIState.Score);
        }
    }

    private void DrawMouseDirection()
    {
        Vector3 startPoint = Vector2.zero;
        Vector3 endPoint = lookDirection * 2f;

        if (_rigidbody.velocity == Vector2.zero)
        {
            lineRenderer.SetPosition(0, startPoint); // 시작점
            lineRenderer.SetPosition(1, endPoint);   // 끝점
        }
        else
        {
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, startPoint);
        }
    }
}
