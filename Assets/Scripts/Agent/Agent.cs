using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;

    private AgentController _agentController;
    private AgentHealth _agentHealth;
    private AgentAnimator _agentAnimator;

    public bool IsMoving { get; private set;} = false;
    public bool IsAlive => _agentHealth.IsAlive;
    public bool IsInjured => _agentHealth.IsInjured;

    private Vector3 _currentDestination;
    private float _minDistance = 0.1f;
    private bool _isDead = false;

    private void Start()
    {
        _agentAnimator = GetComponent<AgentAnimator>();
        _agentController = GetComponent<AgentController>();
        _agentHealth = new AgentHealth(_maxHealth);
    }

    private void Update()
    {
        CheckDestination();
        CheckHit();
        CheckAliveStatus();
    }

    public void Move(Vector3 destination)
    {
        if (IsAlive == false)
        {
            IsMoving = false;
            return;
        }

        _currentDestination = destination;

        _agentController.MakeAgentDestination(destination);

        Vector3 direction = destination - transform.position;

        _agentController.SetInputDirection(direction);

        IsMoving = true;
    }

    private void CheckDestination()
    {
        if (IsMoving == true)
            if (Vector3.Distance(transform.position, _currentDestination) <= _minDistance)
            {
                IsMoving = false;
            }
    }

    private void CheckHit()
    {
        if (_agentHealth.GetHit == true)
        {
            _agentAnimator.TurnOnHitAnimation();
            _agentHealth.TurnOffHit();
        }
    }

    private void CheckAliveStatus()
    {
        if (IsAlive == false && _isDead == false)
        {
            Die();
            _isDead = true;
        }
    }

    private void Die()
    {
        _agentController.StopAgent();
    }

    public void TakeDamage(int hit)
    {
        _agentHealth.TakeDamage(hit);
    }
}
