using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    public int startLife = 10;

    public bool destroyOnKill = false;

    public float delayToKill = 1;

    private int _currentLife;

    private bool _isDead = false;

    [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();

        if(_flashColor == null)
        {
            _flashColor = this.gameObject.GetComponentInChildren<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }

        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }

        /*if(OnKill != null)
        {
            OnKill.Invoke();
        }*/

        OnKill?.Invoke();
    }
}