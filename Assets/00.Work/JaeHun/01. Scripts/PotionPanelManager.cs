using UnityEngine;

public class PotionPanelManager : MonoBehaviour
{
    public GameObject lowPanel;
    public GameObject midPanel;
    public GameObject highPanel;


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
