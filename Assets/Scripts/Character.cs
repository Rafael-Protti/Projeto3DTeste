using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Character : MonoBehaviour
{
    public float maxHealth { get; private set; } = 100;
    public float health { get; private set; }

    public static event Action OnHealthChange;
    public static event Action OnDeath;

    public static Character instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = GetComponent<Character>(); // ou -> instancia = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float value)
    {
        DecreaseValue(value);
    }

    public void Die()
    {
        health = 0;
        OnDeath?.Invoke();
        ChangeCamera();
        Destroy(gameObject);
    }

    void ChangeCamera()
    {
        GameObject.Find("Camera2").GetComponent<Camera>().enabled = true;
    }

    public void ChangeHealth(float value)
    {
        health = value;

        if (health <= 0)
        {
            Die();
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        OnHealthChange?.Invoke();
    }

    public void IncreaseValue(float value)
    {
        if (health + value > maxHealth)
        {
            health = maxHealth;
        }

        else
        {
            health += value;
        }

        OnHealthChange?.Invoke();
    }

    public void DecreaseValue(float value)
    {
        health -= value;

        if (health - value <= 0)
        {
            Die();
        }

        OnHealthChange?.Invoke();

    }
}