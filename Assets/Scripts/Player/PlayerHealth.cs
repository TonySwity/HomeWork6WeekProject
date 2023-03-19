using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private float _invulnerableInSeconds = 1f;
    //[SerializeField] private AudioSource _takeDamageSound;
    //[SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;
    //[SerializeField] private DamageScreen _damageScreen;
    //[SerializeField] private Blink _blink;
    
    private bool _invulnerable = false;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnAddHealth;
    
    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    public void TakeDamage(int damage)
    {
        if (_invulnerable == false)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), _invulnerableInSeconds);
            //_takeDamageSound.Play();
            _healthUI.DisplayHealth(_health);
            //_damageScreen.StartEffect();
            //_blink.StartBlink(); 
            EventOnTakeDamage?.Invoke();
        }
    }

    public void AddHealth(int health)
    {
        _health += health;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        EventOnAddHealth?.Invoke();
        _healthUI.DisplayHealth(_health);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
    
    private void Die()
    {
        Debug.Log("You lose");
    }
}
