using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _BulletSpeed = 10f;
    [SerializeField] private float _shootPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private float _flashTime = 0.12f;

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
        newBullet.GetComponent<Rigidbody>().velocity = _shootPoint.forward * _BulletSpeed;
        _shotSound.pitch = Random.Range(0.8f, 1.2f);
        _shotSound.Play();

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
