using UnityEngine;
using UnityEngine.AI;

public class AgentMover
{
    private NavMeshAgent _navMeshAgent;

    public AgentMover(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
        _navMeshAgent.updateRotation = false;
    }

    public void MakeAgentDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
        _navMeshAgent.isStopped = false;
    }

    public void StopAgent()
    {
        _navMeshAgent.isStopped = true;
    }
}
