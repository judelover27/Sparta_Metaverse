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
        chatName.text = "악마 상인";
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
                chatText = "오늘은 물건이 공짜라네.";
                break;
            case 1:
                chatText = "왼쪽에서 미니게임을 도전해보게";
                break;
            case 2:
                chatText = "아래쪽 사다리로 나가면 게임을 종료할 수 있지.";
                break;
            case 3:
                chatText = "쉬프트를 눌러 양탄자를 탈 수 있다네";
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

    private void OnTriggerEnter2D(Collider2D collision)//상호작용 지역에 들어가면 메세지 on
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
