using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public int Health { get; private set; } = 5;
    [field: SerializeField] public int MaxHealth { get; private set; } = 8;
    [field: SerializeField] public float InvulnerableInSeconds { get; private set; } = 1f;
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
        _healthUI.Setup(MaxHealth);
        _healthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damage)
    {
        if (_invulnerable == false)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), InvulnerableInSeconds);
            //_takeDamageSound.Play();
            _healthUI.DisplayHealth(Health);
            //_damageScreen.StartEffect();
            //_blink.StartBlink(); 
            EventOnTakeDamage?.Invoke();
        }
    }

    public void AddHealth(int health)
    {
        Health += health;

        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        EventOnAddHealth?.Invoke();
        _healthUI.DisplayHealth(Health);
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
