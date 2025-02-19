using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int addScore = 1;
    public float highPosY = 1f;
    public float lowPosY = 0f;

    public float holeSizeMin = -0f;
    public float holeSizeMax = -2f;

    public Transform topObject;//유니티 컴포넌트에서 어떤 오브젝트를 넣을지 정해줘야함
    public Transform bottomObject;

    public float withPadding = 12f;
    public float topBottomWithPaddingMin = 5f;
    public float topBottomWithPaddingMax = 7f;


    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(Random.Range(topBottomWithPaddingMin, topBottomWithPaddingMax), Mathf.Max(halfHoleSize,1));//탑오브젝트 랜덤으로 약간 뒤에배치
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(withPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;//월드 기준으로 obstacle 오브젝트를 배치함 x값은 마지막 포지션+ withpadding y는 high low사이 랜덤값으로한다.

        return placePosition;//현재 포지션은 반환한다 이는 다시 라스트포지션으로 쓰여 재귀 형태로 무한 생성한다.
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        JumpPlayerController player = collision.GetComponent<JumpPlayerController>();
        if (player != null)
        {
            MiniGameGameManager_1.Instance.AddScore(addScore);
        }
    }
}
