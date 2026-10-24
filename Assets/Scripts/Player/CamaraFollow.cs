using System;
using UnityEngine;

namespace Player
{
    public class CamaraFollow : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] SpriteRenderer _spriteLimiter; // Limits camera's movement limiting by using Sprite renderer a.k.a camera bounds
        private Vector3 _offset; // Gap between target's game object and the camera's object 
        float _halfHeight;
        float _halfWidth;
        Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            if(_target == null) return;
            _offset = transform.position - _target.position;
        }
        private void LateUpdate()
        {
            CameraLimits();
        }
        private void FixedUpdate()
        {
            if(_target == null) return;
            transform.position = _target.position + _offset; // Follow the player
        }

        private void CameraLimits()
        {
            _halfHeight = _camera.orthographicSize;
            _halfWidth = _halfHeight * _camera.aspect;
            float clampX = Mathf.Clamp(_target.position.x, _spriteLimiter.bounds.min.x + _halfWidth, _spriteLimiter.bounds.max.x - _halfWidth);
            float clampY = Mathf.Clamp(_target.position.y, _spriteLimiter.bounds.min.y + _halfHeight,
                _spriteLimiter.bounds.max.y - _halfHeight);
            transform.position = new Vector3(clampX, clampY, transform.position.z);
        }
    }
}