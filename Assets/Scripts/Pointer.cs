using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private Camera _playerCamera;
    
    private void Update()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);

        _aimTransform.position = point;

        Vector3 toAim = _aimTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
 