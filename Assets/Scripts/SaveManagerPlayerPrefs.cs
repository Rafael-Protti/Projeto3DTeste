using UnityEngine;

public class SaveManagerPlayerPrefs : MonoBehaviour
{
    public static void Salvar(string nome)
    {
        PlayerPrefs.SetString("nome", nome);
        PlayerPrefs.Save();
    }
}
