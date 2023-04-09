using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentGunIndex;

    private void Start()
    {
        TakeGunInBox(_currentGunIndex);
    }

    public void TakeGunInBox(int gunIndex)
    {
        _currentGunIndex = gunIndex;
        
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)   
    {
        if (numberOfBullets > 0)
        {
            _guns[gunIndex].AddBullets(numberOfBullets);
            TakeGunInBox(gunIndex);
        }
    }
    
}
