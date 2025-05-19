using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageUi : MonoBehaviour
{
    [SerializeField] private Image[] resultImages;
    [SerializeField] private Sprite sprite;
    public int _isHerb = 0;

    void FixedUpdate()
    {
        if (_isHerb == 4)
        {
            _isHerb = 0;
            foreach (var image in resultImages)
            {
                image.sprite = sprite;
            }
        }
    }



    /// <summary>
    /// 허브 배치 하는거
    /// </summary>
    /// <param name="dataSO"></param>
    public void ShowResult(HerbDataSO dataSO)
    {
        if (_isHerb < 3)
        {
            resultImages[_isHerb].sprite = dataSO.herbIcon;
            _isHerb++;
        }
    } 
}
