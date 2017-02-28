using UnityEngine;
using System.Collections;

public class TestAnimator : MonoBehaviour {

    public Animator animator;
	// Use this for initialization
	void Start () {
        AnimatorClipInfo clipInfo = animator.GetCurrentAnimatorClipInfo(0)[0];
        animator.SetTime(0);
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetTime(0);
    }
}
