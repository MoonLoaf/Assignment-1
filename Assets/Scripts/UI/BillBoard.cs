using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    CameraManager cameraManager;

    private void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>().GetComponent<CameraManager>();
    }
    void LateUpdate()
    {
        if (cameraManager.CurrentCamera != null)
        {
            transform.LookAt(transform.position + cameraManager.CurrentCamera.transform.forward);
        }
    }
}
