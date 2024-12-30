using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUtility : MonoBehaviour
{
    public static void SetCursorState(bool visible, CursorLockMode lockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
    }

    public static void EnableCursor()
    {
        SetCursorState(true, CursorLockMode.None);
    }

    public static void DisableCursor()
    {
        SetCursorState(false, CursorLockMode.Locked);
    }

    public static void ConfineCursor()
    {
        SetCursorState(true, CursorLockMode.Confined);
    }

    public static bool IsCursorVisible()
    {
        return Cursor.visible;
    }

    public static CursorLockMode GetCursorLockState()
    {
        return Cursor.lockState;
    }
}
