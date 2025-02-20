using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : BaseController
{
    [SerializeField] public TextMeshProUGUI chatName;
    [SerializeField] public TextMeshProUGUI chat;
    [SerializeField] public GameObject chatBox;
    public PlayerController playerController;

    private bool isPlayerInRange = false;
    private bool isChatBoxActive = false;
    private float moveSpeed = 2f;
    float moveDirection;
    private string chatText;
    private int count = 0;

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

        if (Mathf.Abs(moveDirection) < moveSpeed || isPlayerInRange)
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

    protected override void Update()
    {
        base.Update();
        Interaction();
    }

    protected override void FixedUpdate()
    {

    }

    public void SetChatName()
    {
        chatName.text = "�Ǹ� ����";
    }

    public void SetChat(string _chat)
    {
        chat.text = _chat;
    }

    public void SetRandomChat()
    {
        

        switch (count%4)
        {
            case 0:
                chatText = "������ ������ ��¥���.";
                break;
            case 1:
                chatText = "���ʿ��� �̴ϰ����� �����غ���";
                break;
            case 2:
                chatText = "�Ʒ��� ��ٸ��� ������ ������ ������ �� ����.";
                break;
            case 3:
                chatText = "����Ʈ�� ���� ��ź�ڸ� Ż �� �ִٳ�";
                if(playerController != null) 
                playerController.IsRide = true;
                break;
        }

        count++;
    }

    public void ShowChatBox()
    {
        chatBox.SetActive(true);
    }

    public void HideChatBox()
    {
        chatBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)//��ȣ�ۿ� ������ ���� �޼��� on
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Interaction()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isChatBoxActive)
        {
            SetChatName();
            SetRandomChat();
            SetChat(chatText);
            ShowChatBox();
            isChatBoxActive = true;
        }
        else if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && isChatBoxActive)
        {
            HideChatBox();
            isChatBoxActive = false;
        }
        else if (!isPlayerInRange && isChatBoxActive)
        {
            HideChatBox();
            isChatBoxActive = false;
        }
    }
        
}
