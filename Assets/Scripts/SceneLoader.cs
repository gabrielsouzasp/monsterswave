using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Tempo de espera antes de carregar a próxima cena (em segundos)
    public float delay = 2f;

    void Start()
    {
        // Inicia a contagem regressiva para carregar a próxima cena
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneAsync()
    {
        // Aguarda o tempo de espera
        yield return new WaitForSeconds(delay);

        // Carrega a próxima cena de forma assíncrona
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(BaseScript.LoadLevelScene);

        // Aguarda o término do carregamento da cena
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
