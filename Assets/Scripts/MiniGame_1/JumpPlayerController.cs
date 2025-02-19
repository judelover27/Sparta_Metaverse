using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask CollisionLayer;
    private Camera _camera;
    private Vector2 lookDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private float power = 1f;
    public float chargeSpeed = 5f; // power ���� �ӵ� (�ʴ�)
    public float maxPower = 10f;  // �ִ� power ��
    public float Power {  get { return power; } }

    private bool isDead = true;
    public bool IsDead { get { return isDead; } set { isDead = value; } }


    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isDead) return;

        MouseDirection();
        MouseClickPower();
    }
    private void MouseDirection()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);//���콺�� ��ǥ�� �ػ� ��ǥ�̴� �̰���������ǥ�� ��ȯ
        lookDirection = (worldPos - (Vector2)transform.position).normalized;//transform.position �� Ÿ���� Vector3�̹Ƿ� ĳ���� �ʿ�

    }

    private void MouseClickPower()
    {
        if (Input.GetMouseButton(0)) // ���콺 ���� ��ư�� ������ ������
        {
            power += chargeSpeed * Time.deltaTime; // power ����
            power = Mathf.Min(power, maxPower); // �ִ밪 ����
        }
        else if (Input.GetMouseButtonUp(0)) // ���콺 ��ư�� ���� power �ʱ�ȭ
        {
            Jump(lookDirection, power);
            power = 1f;
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
            MiniGameUIManager_1.Instance.ChangeState(UIState.Score);
        }
    }

}
