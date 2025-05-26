using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.End
{
    public class EndBackGrounds : MonoBehaviour
    {
        [SerializeField] private GameObject backGround;
        
        [SerializeField] private float successDownSpeed = 3;
        [SerializeField] private float failDownSpeed = 3;
        
        private float _downSpeed;

        private void Start()
        {
            if (MoneyManager.Instance.Money >= 10000) _downSpeed = successDownSpeed;
            else _downSpeed = failDownSpeed;
        }

        private void Update()
        {
            if(backGround.transform.position.y < -6500) return;
            
            backGround.transform.position += Vector3.down * (_downSpeed * Time.deltaTime);
        }
    }
}
