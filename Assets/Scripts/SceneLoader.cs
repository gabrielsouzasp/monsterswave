using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Tempo de espera antes de carregar a pr�xima cena (em segundos)
    public float delay = 2f;

    void Start()
    {
        // Inicia a contagem regressiva para carregar a pr�xima cena
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneAsync()
    {
        // Aguarda o tempo de espera
        yield return new WaitForSeconds(delay);

        // Carrega a pr�xima cena de forma ass�ncrona
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(BaseScript.LoadLevelScene);

        // Aguarda o t�rmino do carregamento da cena
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
