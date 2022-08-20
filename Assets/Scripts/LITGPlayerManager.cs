using UnityEngine;

public class LITGPlayerManager : MonoBehaviour
{
    [SerializeField] private LITGGameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private string currentPlayerAnimParameter;
    
    private void Start()
    {
        gameManager = FindObjectOfType<LITGGameManager>().GetComponent<LITGGameManager>();

        if (gameManager == null)
        {
            Debug.LogError("game manager is null");
            return;
        }

        if (gameManager.IsScene2Loaded())
        {
            GetCurrentPlayerAnimParameter();
            StartPlayerAnimation(currentPlayerAnimParameter);
        }
    }

    public void StartPlayerAnimation(string animParameterArg)
    {
        animator.SetTrigger(animParameterArg);
        SetCurrenPlayerAnimParameter(animParameterArg);
        GetCurrentPlayerAnimParameter();
    }
    
    public void SetCurrenPlayerAnimParameter(string newAnimParameter)
    {
        PlayerPrefs.SetString("AnimParameter", newAnimParameter);
    }

    public void GetCurrentPlayerAnimParameter()
    {
        currentPlayerAnimParameter = PlayerPrefs.GetString("AnimParameter");
    }
}
