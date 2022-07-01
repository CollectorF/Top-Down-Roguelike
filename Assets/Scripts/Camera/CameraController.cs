using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(1,5)]
    private float smoothFactor;
    [SerializeField]
    private Transform target;

    private Camera cameraMain;

    private void Awake()
    {
        cameraMain = Camera.main;
    }
    
    private void FixedUpdate()
    {
        FollowTarget();
    }

    internal void SetInitialCameraPosition()
    {
        cameraMain.transform.position = new Vector3(target.position.x, target.position.y + 3, target.position.z);
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 3, target.position.z);
        Vector3 smoothPosition = Vector3.Lerp(cameraMain.transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        cameraMain.transform.position = smoothPosition;
    }
}
