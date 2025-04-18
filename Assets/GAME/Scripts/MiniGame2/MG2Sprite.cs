using UnityEngine;

public class MG2Sprite : MonoBehaviour
{
    private Vector3 _offset;
    private Camera _mainCamera;
    private bool _isDragging;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        _isDragging = true;
        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

    private void OnMouseDrag()
    {
        if (!_isDragging) return;
        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + _offset;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }
}
