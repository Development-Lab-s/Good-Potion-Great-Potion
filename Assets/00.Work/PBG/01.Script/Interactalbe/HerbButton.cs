using System;
using _00.Work.JaeHun._01._Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbDataSO data;
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private ChangeImageUi changeImageUi;
    public string _number;

    void Start()
    {
        InventoryManager.Instance.OnHerbChanged += HandleHurbChanged;
        _number = InventoryManager.Instance.GetHerbCount(data.herbName).ToString();
        _numberText.text = _number;
    }

    private void OnDisable()
    {
        InventoryManager.Instance.OnHerbChanged -= HandleHurbChanged;
        
    }

    private void HandleHurbChanged(string str, int count)
    {
        if (data.herbName != str) return;   
        _numberText.text = $"{count}";
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
                _numberText.text = _number;
                _numberText.text = InventoryManager.Instance.GetHerbCount(data.herbName).ToString();
            }
        }
    }
}