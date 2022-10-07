using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class PlayerCam : MonoBehaviour
{
    public float MouseSensitivity;
    public bool AutoLockCursor;
    public Transform RotationTransform;

    public Camera Cam;

    void Start()
    {
        Cam = this.gameObject.GetComponentInChildren<Camera>();
        Cursor.lockState = (AutoLockCursor) ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void LateUpdate()
    {
        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0);
        gameObject.transform.localEulerAngles = new Vector3(0, this.gameObject.transform.localEulerAngles.y, 0);
        Cam.transform.RotateAround(RotationTransform.position, GetComponentInParent<Transform>().right, Input.GetAxis("Mouse Y") * -MouseSensitivity);
        
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

