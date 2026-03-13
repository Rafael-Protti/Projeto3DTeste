using TMPro;
using UnityEngine;

public class FaseSpeedRun : MonoBehaviour
{
    public TextMeshProUGUI textoTemporizador;

    float temporizador;
    bool iniciouCorrida = false;

    public Transform paredeInicio;
    public Transform paredeFinal;

    void Start()
    {
        paredeInicio.GetComponent<CollisionCallBack>().callback = IniciarCorrida;
        paredeFinal.GetComponent<CollisionCallBack>().callback = FinalizarCorrida;
    }

    void Update()
    {
        if (iniciouCorrida)
        {
            temporizador += Time.deltaTime;
            textoTemporizador.text = temporizador.ToString("00.00").Replace(",",":");
        }
    }

    public void IniciarCorrida()
    {
        iniciouCorrida = true;
    }

    public void FinalizarCorrida()
    {
        iniciouCorrida = false;
    }
}
