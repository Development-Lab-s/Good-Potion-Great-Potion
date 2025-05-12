using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _00.Work.CheolYee._03._Scripts.Customer.TestCreate
{
    public class ShowChat : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI showText;
        
        [SerializeField] private bool isShowing;

        public void OnShowText()
        {
            if (isShowing)
            {
                showText.gameObject.SetActive(false);
                isShowing = false;
            }
            else
            {
                showText.gameObject.SetActive(true);
                isShowing = true;
            }

            showText.text = $"대사: {SceneManagerScript.Instance.currentCustomerData.mainLines[SceneManagerScript.Instance.currentRandomIndex]}\n" +
                            $"힌트 1: {SceneManagerScript.Instance.currentCustomerData.hint[SceneManagerScript.Instance.currentRandomIndex]}\n" +
                            $"힌트 2: {SceneManagerScript.Instance.currentCustomerData.hint2[SceneManagerScript.Instance.currentRandomIndex]}";
        }
    }
}
