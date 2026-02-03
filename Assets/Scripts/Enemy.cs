using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float damage = 9.66666666666666666666666666666666666666f;

    Transform player;

    void OnEnable()
    {
        Character.OnHealthChange += Taunt;
        Character.OnDeath += Die;
    }

    void OnDisable()
    {
        Character.OnHealthChange -= Taunt;
        Character.OnDeath -= Die;
    }
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Taunt()
    {
        Debug.Log("hi hi levei vantagi");
    }

    void Die()
    {
        Debug.Log("GameOver");
        Destroy(gameObject);
    }
    public void ApplyDamage()
    {
        Character.instancia.TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            ApplyDamage();
        }
    }
}
