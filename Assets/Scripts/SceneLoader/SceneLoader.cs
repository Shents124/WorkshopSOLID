using EventSO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private IntEventSO onLoadScene;

    private void OnEnable()
    {
        onLoadScene.onRaisedEvent += LoadScene;
    }

    private void OnDisable()
    {
        onLoadScene.onRaisedEvent -= LoadScene;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private static void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
