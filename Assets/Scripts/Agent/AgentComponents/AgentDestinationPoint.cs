using UnityEngine;

public class AgentDestinationPoint : MonoBehaviour
{
    [SerializeField] private GameObject _point;
    private GameObject _lastPoint;

    public void MakePoint(Vector3 position)
    {
        _lastPoint = Instantiate(_point, position, Quaternion.identity);
    }

    public void DestroyPreviousPoint()
    {
        if (_lastPoint == null)
            return;
        
        Destroy(_lastPoint);
    }
}
