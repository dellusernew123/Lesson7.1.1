using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _isRunningKey = Animator.StringToHash("IsRunning");
    private int _dyingKey = Animator.StringToHash("Died");
    private int _hittingKey = Animator.StringToHash("Hit");

    private int _injuredLayer;
    private bool _isDead;

    private Agent _agent;

    private void Start()
    {
        _injuredLayer = _animator.GetLayerIndex("Injured");
        _agent = GetComponent<Agent>();
    }

    private void Update()
    {
        if (_agent.IsAlive == false)
        {
            if (_isDead == false)
            {
                _isDead = true;
                _animator.SetTrigger(_dyingKey);
            }
            return;
        }
        else if(_agent.IsInjured)
        {
            SwitchToInjuredAnimations();
        }
        
        if (_agent.IsMoving == true)
            TurnOnRunningAnimation();
        else 
            TurnOffRunningAnimation();
    }

    private void TurnOnRunningAnimation()
    {
        _animator.SetBool(_isRunningKey, true);
    }

    private void TurnOffRunningAnimation()
    {
        _animator.SetBool(_isRunningKey, false);
    }

    private void TurnOnDieAnimation()
    {
        _animator.SetTrigger(_dyingKey);
    }

    public void TurnOnHitAnimation()
    {
        _animator.SetTrigger(_hittingKey);
    }

    private void SwitchToInjuredAnimations()
    {
        _animator.SetLayerWeight(_injuredLayer, 1f);
    }
}
