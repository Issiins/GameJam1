using UnityEngine;

namespace Player.States
{
    public static class AnimatorVariables
    {
        public static readonly int Grounded = Animator.StringToHash("OnGround");
        public static readonly int VelocityX = Animator.StringToHash("VelocityX");
        public static readonly int VelocityY = Animator.StringToHash("VelocityY");
    }
}