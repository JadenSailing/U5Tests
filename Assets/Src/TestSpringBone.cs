using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TestSpringBone : MonoBehaviour {
    public Transform Target = null;

    private Vector3 _prePos = Vector3.zero;

    private Transform _targetTransform = null;
    private Transform _selfTransform = null;
    private Vector3 _originDirection;
    private Quaternion _origionRotation;

    private float _length = 1.0f;

    public float Stiffness = 200.0f;
    public float Damping = 500.0f;

	// Use this for initialization
	public void StartSpring () {
        _selfTransform = this.transform;
        _targetTransform = this.Target.transform;
        _prePos = _selfTransform.position;
        _length = Vector3.Distance(_targetTransform.position, _selfTransform.position);
        _originDirection = (_selfTransform.position - _targetTransform.position).normalized;
        _targetTransform.rotation = Quaternion.FromToRotation(Vector3.down, _originDirection);
        _origionRotation = _targetTransform.rotation;
    }
    
	
	// Update is called once per frame
	public void UpdateSpring() {
        float deltaTime = Time.deltaTime;
        Vector3 curPos = _selfTransform.position;
        Vector3 temp = curPos;
        //stiffness
        Vector3 sforce = _originDirection * Stiffness;
        //damping (base on speed)
        Vector3 dforce = -(curPos - _prePos) * Damping;
        Vector3 force = dforce + sforce;
        //verlet
        curPos = curPos + (curPos - _prePos) + force * deltaTime * deltaTime;
        curPos = (curPos - _targetTransform.position).normalized * _length + _targetTransform.position;
        _prePos = temp;
        _selfTransform.position = curPos;
        //target rotates to self
        _targetTransform.rotation = Quaternion.FromToRotation(Vector3.down, curPos - _targetTransform.position);
    }
}
