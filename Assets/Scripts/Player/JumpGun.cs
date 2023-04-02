using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Gun _gun;
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
                _playerRigidbody.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _gun.Shoot();//? как получить с automat
                _isCharge = false;
                _currentCharge = 0;
                _charge.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            _charge.SetChargeValue(_currentCharge,_maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _isCharge = true;
                _charge.StopCharge();
            }
        }
    }
}
