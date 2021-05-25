using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityLife : MonoBehaviour
{


    public int maxLife = 4;

    int _currenLife;

    public int currentLife
    {
        get { return _currenLife; }
        private set
        {
            _currenLife = value;
            _currenLife = Mathf.Clamp(_currenLife, 0, maxLife);
        }
    }


    public bool IsDamaged()
    {
        return currentLife < maxLife;
    }

    void Awake()
    {
        currentLife = maxLife;
    }

    public virtual void GetDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife < 1)
        {
            Dye();
        }
    }

    public void Heal(int heal)
    {
        currentLife = Mathf.Min(currentLife + heal, maxLife);
    }

    protected abstract void Dye();

}
