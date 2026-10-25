using System;
using UnityEngine;

namespace Enviroment
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorButton : MonoBehaviour
    {
        [SerializeField] private Interactable _finishDoor;
        [SerializeField] private float _deltaPress;
        [SerializeField] private float _pressingOffset;
        [SerializeField] private float _deadZone;
        private Vector3 _basePosition;

        private void Awake()
        {
            _basePosition = transform.localPosition;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            float target = _basePosition.y - _pressingOffset;
            while (transform.localPosition.y > target)
            {
                var levelChange = Mathf.MoveTowards(transform.localPosition.y, target, _deltaPress);
                transform.localPosition = new Vector3(transform.localPosition.x, levelChange, transform.localPosition.z);
                if (transform.localPosition.y > _basePosition.y - _deadZone) continue;
                _finishDoor.Trigger(true);
                _finishDoor.Trigger();
                break;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            while (transform.localPosition.y < _basePosition.y)
            {
                var levelChange = Mathf.MoveTowards(transform.localPosition.y, _basePosition.y, _deltaPress);
                transform.localPosition = new Vector3(transform.localPosition.x, levelChange, transform.localPosition.z);
                if(transform.localPosition.y < _basePosition.y - _deadZone) continue;
                _finishDoor.Trigger(false);
                _finishDoor.Trigger();
                break;
            }
            transform.localPosition = _basePosition;
        }
    }
}