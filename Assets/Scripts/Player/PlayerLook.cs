using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform m_camera;
    [SerializeField] private Transform m_player;
    [Space]
    [SerializeField] private float m_mouseSensitivity = 50f;

    public bool m_hideLockCamera = true;

    private float m_xRotation;

    private void Start()
    {
        CursorCheck();
    }

    private void FixedUpdate()
    {
        MouseControl();
    }

    private void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * m_mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * m_mouseSensitivity;

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

        m_camera.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_player.Rotate(Vector3.up * mouseX);
    }

    private void CursorCheck()
    {
        if (m_hideLockCamera && Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
