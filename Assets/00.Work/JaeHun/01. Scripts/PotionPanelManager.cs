using UnityEngine;

public class PotionPanelManager : MonoBehaviour
{
    [SerializeField] GameObject lowPanel;
    [SerializeField] GameObject midPanel;
    [SerializeField] GameObject highPanel;



    private void Start()
    {
        showLow();
    }
    public void showLow()
    {
        lowPanel.SetActive(true);
        midPanel.SetActive(false);
        highPanel.SetActive(false);
    }

    public void showMid()
    {
        lowPanel.SetActive(false);
        midPanel.SetActive(true);
        highPanel.SetActive(false);
    }

    public void showHigh()
    {
        lowPanel.SetActive(false);
        midPanel.SetActive(false);
        highPanel.SetActive(true);
    }
}
