using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbDataSO data;
    [SerializeField] private TextMeshProUGUI _numberText;
    public string _number;

    void Start()
    {
        _number = InventoryManager.Instance.GetHerbCount(data.herbName).ToString();
        _numberText.text = _number;
    }

    public void SetHerb()
    {
        if (herb._inHand == false && InventoryManager.Instance.GetHerbCount(data.herbName) != 0)
        {
            Herb newHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
            newHerb.Initialized(data);

            herb._inHand = true;



            if (InventoryManager.Instance.RevokeHerb(data.herbName))
            {
                --InventoryManager.Instance.totalHerbCount;
                _numberText.text = _number;
                _numberText.text = InventoryManager.Instance.GetHerbCount(data.herbName).ToString();
            }
        }
    }
}
