using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Agent _agent;

    private Vector3 _agentDestinationPosition;
    
    private AgentDestinationPoint _agentDestinationPoint;
    private Camera _camera;

    private void Start()
    {
        _agentDestinationPoint = GetComponent<AgentDestinationPoint>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (LeftMouseButtonWasPressed())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
            {
                _agentDestinationPosition = hit.point;
                _agent.Move(_agentDestinationPosition);

                _agentDestinationPoint.DestroyPreviousPoint();
                _agentDestinationPoint.MakePoint(_agentDestinationPosition);
            }
        }
    }

    private bool LeftMouseButtonWasPressed() => Input.GetMouseButtonDown(0);
}
