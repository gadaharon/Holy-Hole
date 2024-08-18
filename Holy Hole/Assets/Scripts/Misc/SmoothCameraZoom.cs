using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SmoothCameraZoom : MonoBehaviour
{
    Camera cam;
    [SerializeField] CinemachineVirtualCamera vCam;
    float zoom;
    float velocity = 0;
    float smoothTime = 0.5f;

    float minZoom = 5;
    float maxZoom = 20;

    void OnEnable()
    {
        PlayerController.OnHoleSizeChange += ZoomOutCamera;
    }

    void OnDisable()
    {
        PlayerController.OnHoleSizeChange -= ZoomOutCamera;
    }

    void Start()
    {
        cam = Camera.main;
        zoom = vCam.m_Lens.OrthographicSize;
    }

    void ZoomOutCamera(int zoomAmount)
    {
        zoom += zoomAmount;
    }

    void Update()
    {
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        vCam.m_Lens.OrthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }
}
