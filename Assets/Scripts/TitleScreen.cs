using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject loadingScreen;

    [SerializeField]
    private string sceneToTransitionTo;

    [SerializeField]
    private Slider progressBarSlider;

    [SerializeField]
    private Text percentLoadedText;

    private TitleScreenInput inputAction;

    private void Awake()
    {
        inputAction = new TitleScreenInput();
        inputAction.TitleScreen.Enter.performed += ctx => Transition();
    }

    public void Transition()
    {
        inputAction.Disable();

        StartCoroutine(LoadAsynchronously(sceneToTransitionTo));
    }

    private IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = operation.progress;

            progressBarSlider.value = progress;
            percentLoadedText.text = Mathf.CeilToInt(progress * 100).ToString() + "%";

            yield return null;
        }
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}