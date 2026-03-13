using TMPro;
using UnityEngine;
using static Ranking;

public class Classificacao : MonoBehaviour
{
    public Transform classificacaoPrefab;

    void Start()
    {
        StartCoroutine(GameObject.Find("GameManager").transform.GetComponent<Ranking>().Buscar(Listar));
    }

    public void Listar(DadosRankingList dados)
    {
        foreach (DadosRankingFetch dado in dados.items)
        {
            Transform instanciado = Instantiate(classificacaoPrefab, transform);
            instanciado.GetChild(0).GetComponent<TextMeshProUGUI>().text = dado.nome + " | " + dado.tempo;
        }
    }
}
