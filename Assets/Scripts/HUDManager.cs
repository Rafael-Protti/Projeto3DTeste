using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI valorVida;

    public static HUDManager instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = GetComponent<HUDManager>(); // ou -> instancia = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable() //Acontece sempre que o script é ligado. Se ele for desligado e ligado novamente, o código rodará mais uma vez.
    {
        Character.OnHealthChange += AtualizarVida;
    }

    void OnDisable()
    {
        Character.OnHealthChange -= AtualizarVida;
    }

    public void AtualizarVida()
    {
        int textHealth = Mathf.FloorToInt(Character.instancia.health);
        valorVida.text = textHealth.ToString();
    }
}
