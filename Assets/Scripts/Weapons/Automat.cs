using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Automat : Gun
{
    [Space(12)]
    [Header("Automat")]
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private TextMeshProUGUI _bulletText;
    [SerializeField] private PlayerArmory _playerArmory;

    public override void Shoot()
    {
        base.Shoot();
        _numberOfBullets--;
        UpdateText();
        if (_numberOfBullets <= 0)
        {
            _playerArmory.TakeGunInBox(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletText.enabled = false;
    }

    public void UpdateText()
    {
        _bulletText.text = "Пули: " + _numberOfBullets;
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        _numberOfBullets += numberOfBullets;
        UpdateText();
        //_playerArmory.TakeGunInBox(1);// реализация в PlayerArmory
    }
}
