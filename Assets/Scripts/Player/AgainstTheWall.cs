using System;
using UnityEngine;

namespace Player
{
    public class AgainstTheWall : MonoBehaviour
    {
        [SerializeField] private float _distance = 0.5f;
        private const string k_wallLayerName = "Wall"; 
        public bool IsAgainstTheWall()
        {
            var rayHitRight = Physics2D.Raycast(transform.position, Vector2.right, _distance, LayerMask.GetMask(k_wallLayerName));
            var rayHitLeft = Physics2D.Raycast(transform.position, Vector2.left, _distance, LayerMask.GetMask(k_wallLayerName));
            return  rayHitRight.collider != null|| rayHitLeft.collider != null;
        }
    }
}