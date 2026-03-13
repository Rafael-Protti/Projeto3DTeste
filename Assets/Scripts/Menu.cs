using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI nomeTexto;
    string nome;
    public void Jogar()
    {
        if (nome == null) return;
        SceneManager.LoadScene("SpeedRun");
    }

    public void SalvarNome()
    {
        nome = nomeTexto.text;
        SaveManagerPlayerPrefs.Salvar(nome);
    }
}
