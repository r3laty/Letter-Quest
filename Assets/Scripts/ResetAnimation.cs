using UnityEngine;

public class ResetAnimation : MonoBehaviour
{
    private Animator _textAnimator => gameObject.GetComponent<Animator>();

    // Method on animation
    public void AnimationEnd()
    {
        _textAnimator.SetBool("NewLvl", false);
    }
}
