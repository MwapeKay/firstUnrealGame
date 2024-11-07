using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public Transform[] backgroundLayers;
    public float[] scrollSpeeds;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            float parallaxFactor = 1 - 1 / (scrollSpeeds[i] + 1);
            float backgroundTargetPosX = mainCamera.transform.position.x * parallaxFactor;
            Vector3 backgroundNewPos = new Vector3(backgroundTargetPosX, backgroundLayers[i].position.y, backgroundLayers[i].position.z);
            backgroundLayers[i].position = Vector3.Lerp(backgroundLayers[i].position, backgroundNewPos, Time.deltaTime);
        }
    }
}