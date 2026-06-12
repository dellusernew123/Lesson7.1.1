using UnityEngine;

public class AgentHealth
{
    public bool IsInjured { get; private set;} = false;
    public bool IsAlive { get; private set;} = true;
    public bool GetHit { get; private set;} = false;

    private int _maxHealth;
    private int _currentHealth;
    private float _injuredAnimationsPercent = 0.3f;

    public AgentHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int hit)
    {
        _currentHealth -= hit;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            
            IsAlive = false;
        }
        else
        {
            GetHit = true;

            float hpPercent = (float)_currentHealth / (float)_maxHealth;

            if (hpPercent <= _injuredAnimationsPercent)
            {
                IsInjured = true;
            }
        }
    }

    public void TurnOffHit()
    {
        GetHit = false;
    }
}
