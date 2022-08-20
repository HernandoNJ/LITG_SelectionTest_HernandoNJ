using UnityEngine;
using UnityEngine.SceneManagement;

public class LITGGameManager : MonoBehaviour
{
    [Header("Scene values")]
    [SerializeField] private string scene1Name;
    [SerializeField] private string scene2Name;
    [SerializeField] private string currentSceneName;
    [SerializeField] private bool isScene2;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += CheckIfScene2;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckIfScene2;
    }
    
    private void CheckIfScene2(Scene arg0, LoadSceneMode arg1)
    {
        currentSceneName = arg0.name;
        Debug.Log("current scene: " + currentSceneName);
        if (currentSceneName == scene2Name) isScene2 = true;
    }

    public bool IsScene2Loaded() => isScene2;

    public void LoadScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
