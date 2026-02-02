using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI valorVida;

    public static HUDManager instancia;

    private void Awake()
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
    void Start()
    {

    }

    void Update()
    {

    }

    public void AtualizarVida(float health)
    {
        int textHealth = Mathf.FloorToInt(health);
        valorVida.text = textHealth.ToString();
    }
}
