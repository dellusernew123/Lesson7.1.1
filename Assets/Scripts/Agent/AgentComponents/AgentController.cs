using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 900f;
    [SerializeField] private AgentMover _agentMover;
    [SerializeField] private DirectionalRotator _directionalRotator;

    private void Start()
    {
        _agentMover = new AgentMover(GetComponent<NavMeshAgent>());
        _directionalRotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    private void Update()
    {
        _directionalRotator.Update(Time.deltaTime);
    }

    public void SetInputDirection(Vector3 direction) => _directionalRotator.SetInputDirection(direction);

    public void MakeAgentDestination(Vector3 destination) => _agentMover.MakeAgentDestination(destination);
    
    public void StopAgent() => _agentMover.StopAgent();
}
