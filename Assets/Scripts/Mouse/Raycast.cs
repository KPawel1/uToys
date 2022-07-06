using UnityEngine;

public class Raycast
{
    private Camera _camera;

    public Raycast(Camera camera)
    {
        _camera = camera;
    }

 //   public void SetCamera(Camera camera) => _camera = camera; 
    
    public SelectObject StartRaycast(out Vector3 startPosition)
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var raycastHitInfo);
        startPosition = Vector3.zero;
        if(raycastHitInfo.collider == null) return null;
        
        SelectObject currentSelectObject = null;

        if (raycastHitInfo.collider.TryGetComponent(out SelectObject selectObject))
        {
            startPosition = selectObject.gameObject.transform.position;
            currentSelectObject = selectObject;
        }

        return currentSelectObject;
    } 
}