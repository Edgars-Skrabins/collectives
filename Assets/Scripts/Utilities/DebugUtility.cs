using UnityEngine;
using System.Collections;

public static class DebugUtility
{
    public static bool EnableDebugLogs = true;
    public static bool EnableGizmos = true;

    public static void Log(string _message)
    {
        if (EnableDebugLogs)
        {
            Debug.Log(_message);
        }
    }

    public static void DrawGizmo(System.Action _drawAction)
    {
        if (EnableGizmos)
        {
            _drawAction.Invoke();
        }
    }

    public static void CursorLock(bool _value)
    {
        if (_value == true)
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
