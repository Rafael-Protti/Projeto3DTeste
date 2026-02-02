using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float damage = 9.66666666666666666666666666666666666666f;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Character.instancia.TakeDamage(damage);
        }
    }
}
