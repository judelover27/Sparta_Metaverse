using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private string miniGameSceneName = "MiniGameScene_1";
    [SerializeField] private string methodName;
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 textOffset = new Vector3(0, .5f, 0);
    [SerializeField] private string targetTag;
    [SerializeField] private Sprite newSprite;

    private NPCController npcController;

    private void Awake()
    {
        npcController = GetComponent<NPCController>();
    }

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)//��ȣ�ۿ� ������ ���� �޼��� on
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionText?.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionText?.gameObject.SetActive(false);
        }
    }

    private void TrackingText()//�޼��� on �Ǹ� �÷��̾� ������ + offset���� ��ġ �̵� ������Ʈ
    {
        if (interactionText.gameObject.activeSelf)
        {
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.position + textOffset);
            interactionText.transform.position = playerPosition;
        }
    }

    private void Interaction(string methodName)//EŰ ������ ��ȣ�ۿ� Ŭ���� ��Ȱ��
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Invoke(methodName,0);
        }
    }

    private void LoadMiniGame()
    {
        Debug.Log("�̴ϰ������� �̵�");
        SceneManager.LoadScene(miniGameSceneName);
    }

    private void Update()
    {
        TrackingText();

        Interaction(methodName);
        
    }

        
    public void ShowSB()
    {
        GameManager.Instance.scoreBoardManager.ShowScoreBoard();
    }

    public void GE()
    {
        GameManager.Instance.GameEnd();
    }


    public void ChangeSprite()
    {
        // Ư�� �±׸� ���� �ڽ� ������Ʈ ã�� ���� findwithtag�� �� ��ü Ž���ϹǷ� ���ڿ� ���� ���� �� �ϳ��� �־�ߵ�
        GameObject child = GameObject.FindWithTag(targetTag);

        if (child != null)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                spriteRenderer.sprite = newSprite;
            else 
                Debug.Log("spriteRender is null");
        }
        else
            Debug.Log("Tag Object is Null");
    }



}
