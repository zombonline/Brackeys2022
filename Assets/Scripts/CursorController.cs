using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static void CursorHide()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public static void CursorShow()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
