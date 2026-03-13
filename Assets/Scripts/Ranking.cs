using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
using static UnityEditor.PlayerSettings;

public class Ranking : MonoBehaviour
{
    public string supabaseUrl = "https://gcocizuchqqizuhchrpw.supabase.co/rest/v1/ranking";
    public string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imdjb2NpenVjaHFxaXp1aGNocnB3Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzMzU5MTIsImV4cCI6MjA4ODkxMTkxMn0.g53tJNR-aOxfhACmKAF8g7iHGHlmy_8GeTXQD1I6pkY";

    [System.Serializable]
    public class DadosRanking
    {
        //public int id;
        public string nome;
        public float tempo;
        //public string criado_em;
    }

    [System.Serializable]
    public class DadosRankingFetch
    {
        public int id;
        public string nome;
        public float tempo;
        public string criado_em;
    }

    [System.Serializable]
    public class DadosRankingList
    {
        public DadosRankingFetch[] items;
    }

    public void Inserir(string nome, float tempo)
    {
        DadosRanking dados = new DadosRanking();
        dados.nome = nome;
        dados.tempo = tempo;

        StartCoroutine(InserirBanco(dados));
    }

    IEnumerator InserirBanco(DadosRanking dados)
    {

        string json = JsonUtility.ToJson(dados);

        using (UnityWebRequest request = new UnityWebRequest(supabaseUrl, "POST")) // POST -> armazenar/enviar ; GET -> pegar/obter ; UPDATE -> Recarrega ; DELETE -> deleta...
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("apikey", supabaseKey);
            request.SetRequestHeader("Authorization", "Bearer " + supabaseKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Dados salvos com sucesso");
            }

            else
            {
                Debug.Log("Erro ao salvar no banco: " + request.error);
                Debug.Log("Detalhes do erro: " + request.downloadHandler.text);
            }
        }
    }

    public IEnumerator Buscar(System.Action<DadosRankingList> callback)
    {

        using (UnityWebRequest request = UnityWebRequest.Get(supabaseUrl))
        {
            request.SetRequestHeader("apikey", supabaseKey);
            request.SetRequestHeader("Authorization", "Bearer " + supabaseKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                //Debug.Log(request.downloadHandler.text);
                string json = "{ \"items\":" + request.downloadHandler.text + "}";
                DadosRankingList dados = JsonUtility.FromJson<DadosRankingList>(json);

                callback(dados);
            }

            else
            {
                Debug.Log("Erro ao salvar no banco: " + request.error);
                Debug.Log("Detalhes do erro: " + request.downloadHandler.text);
            }
        }
    }
}
