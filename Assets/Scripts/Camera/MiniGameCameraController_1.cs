using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCameraController_1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    void LateUpdate()//�ε巯�� ī�޶� ������ ���� lerp�� lateUpdate ���
    {
        if (MiniGameGameManager_1.Instance.jumpPlayerController.IsDead) return;
        Vector3 desiredPosition = player.transform.position + offset;
        desiredPosition.y = 0f;
        desiredPosition.z = -10f;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
