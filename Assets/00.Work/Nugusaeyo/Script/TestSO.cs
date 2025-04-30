using UnityEngine;

[CreateAssetMenu(menuName = "testSO")]
public class TestSO : ScriptableObject
{
    [SerializeField] public Sprite itemImage;
    [SerializeField] public string itemName;
    [SerializeField] public int itemAmount;
    public int testA;
    [SerializeField] private int testB;
}
