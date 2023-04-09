using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private int _segments = 10;
    [SerializeField] private LineRenderer _lineRenderer;
    
    public void Draw(Vector3 a, Vector3 b, float lenght)
    {
        _lineRenderer.enabled = true;
        
        float interpolationDistance = Vector3.Distance(a, b) / lenght;
        float offset = Mathf.Lerp(lenght / 2, 0f, interpolationDistance);
        
        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        _lineRenderer.positionCount = _segments + 1;

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            _lineRenderer.SetPosition(i,BezierCurve.GetPointOptimizationFunction(a, aDown, bDown, b,(float)i/ _segments));
        }
    }

    public void Hide()
    {
        _lineRenderer.enabled = false;
    }
}
