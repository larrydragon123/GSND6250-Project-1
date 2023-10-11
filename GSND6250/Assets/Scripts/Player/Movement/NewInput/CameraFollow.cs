using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Vector2 maxFollowOffset = new Vector2(-1f, 6f);
    [SerializeField] private Vector2 cameraVelocity = new Vector2(4f, 0.25f);
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    public void OnStartAuthority()
    {
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        virtualCamera.gameObject.SetActive(true);

        enabled = true;
    }
    
}
