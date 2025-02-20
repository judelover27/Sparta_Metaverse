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
    

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)//상호작용 지역에 들어가면 메세지 on
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

    private void TrackingText()//메세지 on 되면 플레이어 포지션 + offset으로 위치 이동 업데이트
    {
        if (interactionText.gameObject.activeSelf)
        {
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.position + textOffset);
            interactionText.transform.position = playerPosition;
        }
    }

    private void Interaction(string methodName)//E키 누르면 상호작용 클래스 재활용
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Invoke(methodName,0);
        }
    }

    private void LoadMiniGame()
    {
        Debug.Log("미니게임으로 이동");
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
}
