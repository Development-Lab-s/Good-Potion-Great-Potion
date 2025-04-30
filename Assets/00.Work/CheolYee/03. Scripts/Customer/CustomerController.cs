using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerController : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        
        private static readonly int Enter = Animator.StringToHash("Enter");
        private static readonly int Exit = Animator.StringToHash("Exit");

        public void SetCustomerSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void PlayEnterAnimation()
        {
            animator.SetTrigger(Enter);
        }

        public void PlayExitAnimation()
        {
            animator.SetTrigger(Exit);
        }

    }
}
