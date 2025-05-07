using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour       //���� ����� �����ؼ� �θ���.
{
    public static InventoryManager Instance;
    private Dictionary<string, int> herbInventory = new Dictionary<string, int>();//Dictionary�� ��� �̸��̶� ���� �����ϴ°���.

    [SerializeField] private string[] herbNames;  //��� ��긦 �迭�� �־��ֱ����� �迭.

    private void Awake()
    {
        if (Instance == null) Instance = this;    //�̰Ŵ� �� �˰Ŷ�� ������.
        else Destroy(gameObject);                 //���� �𸥴ٸ� �׳� �ٸ� �� ���� �����ϴ°Ŷ� ������

        foreach (string name in herbNames)      //�����ӿ��� �̸����� �˻��ϴ°Ÿ� ó������ 0���� �������
        {                                       //�� �ָ��ϱ� �ѵ� �׳� Inspector�� �Էµ� ��� �̸��� �ϳ��� �����ͼ�, ���� ������ 0���� �ʱ�ȭ ���شٰ� ������.
            herbInventory[name] = 0;
        }

    }
    public void Addherb(string herbName)         //���ϱ�
    {
        if (herbInventory.ContainsKey(herbName))        //���ã��
        {
            herbInventory[herbName]++;
            Debug.Log($"{herbName} +1 �� ���� ����: {herbInventory[herbName]}"); //�̰Ŵ� �� �������.
        }
    }
    public void RemoveHurb(string herbName)       //����
    {
        if (herbInventory.ContainsKey(herbName))
        {
            if (herbInventory[herbName] > 0)   //���� ����
            {
                herbInventory[herbName]--;
                Debug.Log($"{herbName} -1 �� ���� ����: {herbInventory[herbName]}");
            }
        }
    }
    public int GetHerbCount(string herbName) //�ܺο��� ���� ��� ������ Ȯ�� �� �� �ִ� �Լ�
    {
        return herbInventory.ContainsKey(herbName) ? herbInventory[herbName] : 0; //���� ��긦 �����ϸ� 0�� ��ȯ�Ѵ�.
                                                                                  //�κ��丮���� ã������ ��갡 ������� ��긦 �κ��丮�� �ִ´�. �ƴҰ�� 0�� ��ȯ.
    }
}






