using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private string miniGameSceneName = "MiniGameScene";

    // TextMeshPro UI ���۷���
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 textOffset = new Vector3(0, .5f, 0);

    private void Start()
    {
        // ������ �⺻������ ��Ȱ��ȭ
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

    private void Update()
    {
        // ������ �÷��̾� �Ӹ� ���� ����ٴ�
        if (interactionText.gameObject.activeSelf)
        {
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.position + textOffset);
            interactionText.transform.position = playerPosition;
        }

        // E Ű�� ������ �� �̴ϰ��� ������ �̵�
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("�̴ϰ������� �̵�");
            SceneManager.LoadScene(miniGameSceneName);
        }
    }
}
