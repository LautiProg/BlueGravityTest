using UnityEngine;

namespace Player
{
    public class PlayerAnimationController
    {
        private readonly Animator _animator;
        private readonly PlayerMovement _playerMovement;
    
        public PlayerAnimationController(Animator animator, PlayerMovement playerMovement)
        {
            _animator = animator;
            _playerMovement = playerMovement;

            _playerMovement.OnIdle += IdleAnimation;
            _playerMovement.OnMovement += MovementAnimation;
        }
    
        private void IdleAnimation()
        {
            _animator.SetBool("OnIdle", true);
            _animator.SetBool("OnMovement", false);
        }

        private void MovementAnimation()
        {
            _animator.SetBool("OnIdle", false);
            _animator.SetBool("OnMovement", true);
        }
    }
}