using UnityEngine;

public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _positionY = 2f;
    private Camera _camera;
    public void SetCamera(Camera camera) => _camera = camera; 
    
    public void MoveSelectObject(SelectObject currentSelectObject)
    {
        var objectTransform = currentSelectObject.gameObject.transform;
        var positionMouse = Input.mousePosition;
        positionMouse.z =  _camera.transform.position.y; 
        var worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
        objectTransform.position = new Vector3(worldMousePosition.x, _positionY, worldMousePosition.z);

    }

    public void ResetSelectObject(SelectObject currentSelectObject, Vector3 _startPosition)
    {
        var objectTransform = currentSelectObject.gameObject.transform;
        objectTransform.position =
            new Vector3(objectTransform.position.x, _startPosition.y, objectTransform.position.z);

    }
}