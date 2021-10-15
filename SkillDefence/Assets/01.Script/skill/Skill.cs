using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float initHealth;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action OnDeath;
    public RectTransform rect;

    public void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    protected virtual void OnEnable()
    {
        dead = false;
        health = initHealth;
    }

    public virtual void OnDamage(float damage, Vector3 position, Vector3 normal)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(float value)
    {
        if (dead) return;
        health += value;
    }
    public virtual void Die()
    {
        if (OnDeath != null) OnDeath();
        dead = true;
    }

    public void Move()
    {
        if(rect.anchoredPosition.x <= 2400f)
        {
            float x1 = rect.anchoredPosition.x;
            x1 += 1f;
            rect.anchoredPosition = new Vector3(x1, 0);
        }
    }
}
