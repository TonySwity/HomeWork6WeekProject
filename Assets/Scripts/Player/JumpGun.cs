using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _maxCharge = 3;
    [SerializeField] private ChargeIcon _charge;

    private float _currentCharge;
    private bool _isCharge;

    private void Update()
    {
        if (_isCharge)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                foreach (var gun in _guns)
                {
                    if (gun.gameObject.activeSelf)
                    {
                        _playerRigidbody.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                        gun.Shoot(); //? как получить с automat
                        _isCharge = false;
                        _currentCharge = 0;
                        _charge.StartCharge();

                        break;
                    }
                }
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            _charge.SetChargeValue(_currentCharge, _maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _isCharge = true;
                _charge.StopCharge();
            }
        }
    }
}
