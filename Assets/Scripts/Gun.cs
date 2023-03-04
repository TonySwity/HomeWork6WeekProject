using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _shootPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    private float _timer;

    private void Start()
    {
        HideFlash();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer > _shootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Bullet newBullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = _shootPoint.forward * _speed;
                _shotSound.pitch = Random.Range(0.8f, 1.2f);
                _shotSound.Play();
                _flash.SetActive(true);
                Invoke(nameof(HideFlash), 0.12f);
            }
        }
    }

    private void HideFlash()
    {
        _flash.SetActive(false);
    }
}
