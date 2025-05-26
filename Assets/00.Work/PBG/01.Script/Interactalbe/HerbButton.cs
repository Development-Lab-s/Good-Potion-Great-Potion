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
        InventoryManager.Instance.OnHerbChanged += HandleHurbChanged;
        _number = InventoryManager.Instance.GetHerbCount(data.herbName).ToString();
        _numberText.text = _number;
    }
    private void HandleHurbChanged(string str, int count)
    {
        InventoryManager.Instance.OnHerbChanged += HandleHurbChanged;
        if (data.herbName != str) return;   
        _numberText.text = $"{count}";
        InventoryManager.Instance.OnHerbChanged -= HandleHurbChanged;
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
        else if (herb._inHand)
        {

            Herb[] taggedObjects = GameObject.FindObjectsByType<Herb>(FindObjectsSortMode.None);

            foreach (Herb obj in taggedObjects)
            {
                if (data.herbName == obj.data.herbName)
                {
                    InventoryManager.Instance.AddHerb(obj.data.herbName, 0);
                    _numberText.text = InventoryManager.Instance.GetHerbCount(obj.data.herbName).ToString();

                    herb._inHand = false;
                    Destroy(obj.gameObject);
                    taggedObjects[0] = null;

                }
            }
        }
    }
}
