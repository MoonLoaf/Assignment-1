using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class PlayerCam : MonoBehaviour
{
    public float mouseSensitivity;
    public bool autoLockCursor;
    public Transform rotationTransform;

    public Camera cam;

    void Awake()
    {
        this.gameObject.GetComponentInChildren<Camera>();
        Cursor.lockState = (autoLockCursor) ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void Update()
    {
        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        gameObject.transform.localEulerAngles = new Vector3(0, this.gameObject.transform.localEulerAngles.y, 0);
        cam.transform.RotateAround(rotationTransform.position, GetComponentInParent<Transform>().right, Input.GetAxis("Mouse Y") * -mouseSensitivity);

        
        
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

