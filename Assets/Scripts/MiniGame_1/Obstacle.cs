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

    public Transform topObject;//����Ƽ ������Ʈ���� � ������Ʈ�� ������ ���������
    public Transform bottomObject;

    public float withPadding = 12f;
    public float topBottomWithPaddingMin = 5f;
    public float topBottomWithPaddingMax = 7f;


    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(Random.Range(topBottomWithPaddingMin, topBottomWithPaddingMax), Mathf.Max(halfHoleSize,1));//ž������Ʈ �������� �ణ �ڿ���ġ
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(withPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;//���� �������� obstacle ������Ʈ�� ��ġ�� x���� ������ ������+ withpadding y�� high low���� �����������Ѵ�.

        return placePosition;//���� �������� ��ȯ�Ѵ� �̴� �ٽ� ��Ʈ���������� ���� ��� ���·� ���� �����Ѵ�.
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
