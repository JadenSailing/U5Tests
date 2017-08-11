using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JSAnimation : MonoBehaviour {

    private Animation _animation;

    public List<AnimationClip> Clips;

    public float fadeTime = 0.3f;

    private bool _isPlaying = false;
    private int _currentIndex = 0;

	// Use this for initialization
	void Start () {
        _animation = this.GetComponent<Animation>();
        this.Play();
	}

    /// <summary>
    /// 从头播放
    /// </summary>
    private void Play()
    {
        if (_animation == null)
        {
            return;
        }
        if(Clips == null || Clips.Count == 0)
        {
            return;
        }
        for (int i = 0; i < Clips.Count; i++)
        {
            AnimationClip clip = Clips[i];
            if(_animation.GetClip(clip.name) == null)
            {
                _animation.AddClip(clip, clip.name);
            }
        }

        this.PlayAnimation(0);
    }

    private void OnEnable()
    {
        this.Play();
    }

    private void PlayAnimation(int index)
    {
        if (index < 0 || index >= Clips.Count)
        {
            _isPlaying = false;
            return;
        }
        if(Clips[index] == null)
        {
            _isPlaying = false;
            return;
        }
        _currentIndex = index;
        if(index == 0)
        {
            _animation.Play(Clips[index].name);
        }
        else
        {
            _animation.Play(Clips[index].name);
            //_animation.CrossFade(Clips[index].name, fadeTime);
        }
        _isPlaying = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(!_isPlaying)
        {
            return;
        }
        AnimationState state = _animation[Clips[_currentIndex].name];

        /*
        if(state.time >= state.length)
        {
            this.PlayAnimation(_currentIndex + 1);
        }
        */
        if(state.enabled == false)
        {
            this.PlayAnimation(_currentIndex + 1);
        }
	}
}
