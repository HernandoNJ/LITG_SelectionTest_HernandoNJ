using System;
using UnityEngine;

public class LITGPlayerManager : MonoBehaviour
{
    [SerializeField] protected LITGGameManager gameManager;
    [SerializeField] protected Animator animator;
    [SerializeField] protected string currentPlayerAnimParameter;
    [SerializeField] protected bool isUiPlayer;

    private void Start()
    {
        gameManager = FindObjectOfType<LITGGameManager>().GetComponent<LITGGameManager>();

        if (gameManager == null)
        {
            Debug.LogError("game manager is null");

            return;
        }

        if (gameManager.IsScene2Loaded() && isUiPlayer)
        {
            GetCurrentPlayerAnimParameter();
            StartPlayerAnimation(null, currentPlayerAnimParameter);
        }
    }

    public void StartPlayerAnimation(string triggerAnimParameter)
    {
        if (triggerAnimParameter != null)
        {
            animator.SetTrigger(triggerAnimParameter);
        }
        SetCurrenPlayerAnimParameter(triggerAnimParameter);
        GetCurrentPlayerAnimParameter();
    }

    public void StartPlayerAnimation(string boolAnimParameter, string triggerAnimParameter)
    {
        if (boolAnimParameter != null) animator.SetBool(boolAnimParameter, true);
        if (triggerAnimParameter != null || triggerAnimParameter != String.Empty)
            animator.SetTrigger(triggerAnimParameter);
        SetCurrenPlayerAnimParameter(boolAnimParameter);
        GetCurrentPlayerAnimParameter();
    }

    public void StopPlayerAnimation(string boolAnimParameter)
    {
        if (boolAnimParameter != null) animator.SetBool(boolAnimParameter, false);
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
