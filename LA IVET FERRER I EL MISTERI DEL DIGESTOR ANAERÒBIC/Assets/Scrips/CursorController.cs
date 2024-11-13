using UnityEngine;
public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture1, cursorTexture2;
    private void Start()
    {
        SetCursor(cursorTexture1);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetCursor(cursorTexture2);
        if (Input.GetMouseButtonUp(0))
            SetCursor(cursorTexture1);
    }
    private void SetCursor(Texture2D cursorTexture)
    {
        Debug.Log("Cambiar cursor mode bug amb WebGL");
        cursorTexture.SetPixel(0, 0, Color.clear);
        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
