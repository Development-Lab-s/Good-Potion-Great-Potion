using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbDataSO data;
    [SerializeField] private TextMeshProUGUI _numberText;
    private string _number;

    void Start()
    {
        _number = InventoryManager.Instance.totalHerbCount.ToString();
    }

    public void SetHerb()
    {
        if (herb._inHand == false)
        {
            Herb newHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
            newHerb.Initialized(data);

            herb._inHand = true;

            if (InventoryManager.Instance.RevokeHerb(data.herbName))
            {
                _numberText.text = _number;
                Debug.Log(1);
            }
            else
            {
                _numberText.text = "0";
            }
        }
    }
}
