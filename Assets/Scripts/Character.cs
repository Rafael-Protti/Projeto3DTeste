using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Character : MonoBehaviour
{
    public float maxHealth { get; private set; } = 100;
    public float health { get; private set; }

    public static Character instancia;

    private void Awake()
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

    private void Start()
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
        Destroy(gameObject);
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

        HUDManager.instancia.AtualizarVida(health);
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

        HUDManager.instancia.AtualizarVida(health);
    }

    public void DecreaseValue(float value)
    {
        health -= value;

        if (health - value <= 0)
        {
            Die();
        }

        HUDManager.instancia.AtualizarVida(health);
    }
}
