using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
