using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticle;

    public void RunExplosionParticle()
    {
        ParticleSystem particle = Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        particle.Play();
    }
}
