using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private Image _healthBar;

    private float _maxHealth = 100;
    private float _currentHealth;
    public float Health { get { return _currentHealth; } }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }


    /// <summary>
    /// Updates Current Health; By default subtracts value from hp;
    /// </summary>
    /// <param name = "value" > The amount by which the hp will change.</param>
    /// <param name = "substractFromHealth" > True by default; Set to false if you want to add the value to the hp. </param>
    public void UpdateHealth(float value = 10, bool substractFromHealth = true)
    {
        if (substractFromHealth == false) _currentHealth += value;
        else _currentHealth -= value;
        UpdateHealthBar();
        ReadyToDie();
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _currentHealth/_maxHealth;
    }

    private void ReadyToDie()
    {
        if(_currentHealth <= 0)
        {
           gameObject.SetActive(false);
        }
    }
}
