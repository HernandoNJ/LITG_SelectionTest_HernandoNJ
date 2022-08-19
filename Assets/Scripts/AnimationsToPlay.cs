using UnityEngine;

public class AnimationsToPlay : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void StartHouseDancingAnimation()
    {
        _animator.SetTrigger("HouseDancing");
    }
    
    public void StartMacarenaDanceAnimation()
    {
        _animator.SetTrigger("MacarenaDance");
    }
    
    public void StartWaveHipHopAnimation()
    {
        _animator.SetTrigger("WaveHipHop");
    }
}