using _00.Work.CheolYee._03._Scripts.Customer;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using TMPro;
using UnityEngine;

public class HintBtn : MonoBehaviour
{
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private TextMeshProUGUI hintText;
    
    private bool isBtnClicked = false;

    public void HintBtnClicked()
    {
        isBtnClicked = !isBtnClicked;
        
        hintPanel.SetActive(isBtnClicked);


        if (SceneManagerScript.Instance.btnClickCount == 2)
        {
            hintText.text = null;
            hintText.text = $"{SceneManagerScript.Instance.currentCustomerData.mainLines[CustomerChatManager.Instance.randomIndex]}";
            
            
        }
    }
}
