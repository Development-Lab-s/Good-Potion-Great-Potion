using System;
using _00.Work.CheolYee._03._Scripts.Customer;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using TMPro;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts
{
    public class HintBtn : MonoBehaviour
    {
        [SerializeField] private GameObject hintPanel;
        [SerializeField] private TextMeshProUGUI hintText;
    
        private bool _isBtnClicked;

        public void HintBtnClicked()
        {
            _isBtnClicked = !_isBtnClicked;
        
            hintPanel.SetActive(_isBtnClicked);


            if (SceneManagerScript.Instance.btnClickCount == 2)
            {
                hintText.text = null;
                hintText.text = $"대사 : {SceneManagerScript.Instance.currentCustomerData.mainLines[CustomerChatManager.Instance.randomIndex]}\n"+ 
                                $"힌트 : {SceneManagerScript.Instance.currentCustomerData.hint[0]}\n" + 
                                $"힌트 2: {SceneManagerScript.Instance.currentCustomerData.hint2[0]}";
            }
            else if (SceneManagerScript.Instance.btnClickCount == 1)
            {
                hintText.text = null;
                hintText.text =
                    $"대사 : {SceneManagerScript.Instance.currentCustomerData.mainLines[CustomerChatManager.Instance.randomIndex]}\n" +
                    $"힌트 : {SceneManagerScript.Instance.currentCustomerData.hint[0]}";
            }
            else
            {
                hintText.text = null;
                hintText.text =
                    $"대사 : {SceneManagerScript.Instance.currentCustomerData.mainLines[CustomerChatManager.Instance.randomIndex]}";
            }
        }
    }
}
