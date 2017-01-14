using UnityEngine;
using System.Collections;

/// <summary>
/// Time.timeScale影响Time.time数值 不影响Time.realtimeSinceStartup
/// </summary>
public class TestTime : MonoBehaviour {

    private float _currentTime = 0.0f;
    private float _currentRealTime = 0.0f;

    ParticleSystem _ps = null;

    // Use this for initialization
    void Start () {
        GameObject psObj = new GameObject("Ps");
        _ps = psObj.AddComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {

        //粒子绕过timescale的限制 --性能有点问题
        _ps.Simulate(Time.realtimeSinceStartup - _currentRealTime, true, false);

        _currentTime = Time.time;
        _currentRealTime = Time.realtimeSinceStartup;

    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(100, 0, 200, 100), "Rate+0.1"))
        {
            float t = Time.timeScale * 1.1f;
            t = t > 100 ? 100 : t;
            Time.timeScale = t;
        }
        if(GUI.Button(new Rect(100, 100, 200, 100), "Rate-0.1"))
        {
            float t = Time.timeScale * 0.9f;
            t = t < 0 ? 0 : t;
            Time.timeScale = t;
        }

        GUI.Label(new Rect(500, 200, 100, 100), _currentTime.ToString());

        GUI.Label(new Rect(500, 300, 100, 100), _currentRealTime.ToString());
    }
}
