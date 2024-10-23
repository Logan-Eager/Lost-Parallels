using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    private void Start()
    {
        ShowTheCursor();
    }
    public void OnButtonClick()
    {
        Cursor.visible = false; // Hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowTheCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
