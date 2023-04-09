using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shootPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private float _flashTime = 0.02f;
    [SerializeField] private ParticleSystem _shootEffect;

    private float _timer;

    private void Start()
    {
        _flash.SetActive(false);
    }

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        
        if (_timer > _shootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                
                Shoot();
            }
        }
    }

    public virtual void Shoot()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _shootPoint.forward * _bulletSpeed;
        _shotSound.pitch = Random.Range(0.8f, 1.2f);
        _shotSound.Play();
        if (_shootEffect != null)
        {
            _shootEffect.Play();
        }
        
        StartCoroutine(HideFlash());
    }

    private IEnumerator HideFlash()
    {
        _flash.SetActive(true);
        yield return new WaitForSeconds(_flashTime);
        _flash.SetActive(false);
    }

    public virtual void Activate()
    {
        _flash.SetActive(false);
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {
        
    }
}
