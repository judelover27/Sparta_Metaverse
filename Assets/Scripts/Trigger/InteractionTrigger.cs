using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private string miniGameSceneName = "MiniGameScene";

    // TextMeshPro UI 레퍼런스
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 textOffset = new Vector3(0, .5f, 0);

    private void Start()
    {
        // 문구를 기본적으로 비활성화
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
        // 문구가 플레이어 머리 위에 따라다님
        if (interactionText.gameObject.activeSelf)
        {
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.position + textOffset);
            interactionText.transform.position = playerPosition;
        }

        // E 키를 눌렀을 때 미니게임 씬으로 이동
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("미니게임으로 이동");
            SceneManager.LoadScene(miniGameSceneName);
        }
    }
}
