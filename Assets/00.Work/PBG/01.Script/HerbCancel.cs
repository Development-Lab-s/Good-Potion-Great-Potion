using System.Data.Common;
using UnityEngine;

public class HerbCancel : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbButton herbButton;
    public void ReturnHerb()
    {

        Herb[] taggedObjects = GameObject.FindObjectsByType<Herb>(FindObjectsSortMode.None);


        if (taggedObjects.Length > 0)
        {
            foreach (Herb obj in taggedObjects)
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
