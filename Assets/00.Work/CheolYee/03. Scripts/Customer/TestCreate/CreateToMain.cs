using _00.Work.Base._02._Sprites.Manager;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.CheolYee._03._Scripts.Customer.TestCreate
{
    public class CreateToMain : MonoBehaviour
    {
        public void InToMainSecne()
        {
            SceneManagerScript.Instance.isFinishedCrafting = true;

            if (SceneManagerScript.Instance != null && HerbRecipeManager.Instance != null)
            {
                if (HerbRecipeManager.Instance._potionName ==
                    SceneManagerScript.Instance.currentCustomerData.requiredPotions) //만약 만든 포션이 손님의 주문과 같다면
                {
                    SceneManagerScript.Instance.isSuccessCrafting = true; //제작 성공으로 만들고
                    SceneManagerScript.Instance.isSuccessCraftingCount++; // 성공 횟수+1
                }
                else
                {
                    SceneManagerScript.Instance.isSuccessCrafting = false;
                }
            }
            else
            {
                SceneManagerScript.Instance.isSuccessCrafting = false;
            }
            
            SceneManagerScript.Instance.LoadToScene(1);
        }
        
        public void InToMainSecneFail()
        {
            SceneManagerScript.Instance.isFinishedCrafting = true;
            SceneManagerScript.Instance.isSuccessCrafting = false;
            SceneManagerScript.Instance.LoadToScene(1);
        }
    }
}
