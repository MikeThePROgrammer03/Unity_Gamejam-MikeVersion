using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private bool _enable = true;
    [SerializeField, Range(0, 0.1f)] private float _Amplitude = 0.015f; 
    [SerializeField, Range(0, 30)] private float _frequency = 10.0f;
    [SerializeField] private Transform _cameraHolder = null;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    [SerializeField] private CharacterController _controller;

    private void Awake()
    {
        _startPos = _cameraHolder.localPosition;
    }

    void Update()
    {
        if (!_enable) return;
        CheckMotion();
        ResetPosition();
        _cameraHolder.LookAt(FocusTarget());
    }
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _Amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _Amplitude * 2;
        return pos;
    }
    private void CheckMotion()
    {
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;
        if (speed < _toggleSpeed) return;
        if (!_controller.isGrounded) return;

        PlayMotion(FootStepMotion());
    }
    private void PlayMotion(Vector3 motion)
    {
        _cameraHolder.localPosition += motion;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }
    private void ResetPosition()
    {
        if (_cameraHolder.localPosition == _startPos) return;
        _cameraHolder.localPosition = Vector3.Lerp(_cameraHolder.localPosition, _startPos, 3 * Time.deltaTime);
    }
}