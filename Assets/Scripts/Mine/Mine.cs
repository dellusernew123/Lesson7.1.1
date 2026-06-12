using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 100;
    [SerializeField] private float _timeBeforeExplosion = 5f;

    private bool _isMineTimerActive = false;
    private bool _isExploding = false;

    private float _currentTime;

    private ExplosionParticle _explosionParticle;
    private SphereCollider _sphereCollider;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _explosionParticle = GetComponent<ExplosionParticle>();
        _currentTime = _timeBeforeExplosion;
    }

    private void Update()
    {
        if(_isMineTimerActive == true)
            RunMineTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isMineTimerActive) return;

        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            _isMineTimerActive = true;
        }
    }

    private void Explode()
    {
        _explosionParticle.RunExplosionParticle();

        Collider[] allColliders = Physics.OverlapSphere(transform.position, _sphereCollider.radius);

        foreach (Collider collider in allColliders)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageableObject))
            {
                damageableObject.TakeDamage(_damage);
            }
        }
            
        Destroy(gameObject);
    }

    private void RunMineTimer()
    {
        _currentTime -= Time.deltaTime;

        if(_currentTime <= 0 && _isExploding == false)
        {
            Explode();
            _isExploding = true;
        }
    }
}
