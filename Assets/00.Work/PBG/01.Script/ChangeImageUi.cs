using UnityEngine;
using UnityEngine.UI;

public class ChangeImageUi : MonoBehaviour
{
    [SerializeField] private Image resultImage;
    [SerializeField] private Image resultImage2;
    [SerializeField] private Image resultImage3;

    [SerializeField] private Sprite herb1;
    [SerializeField] private Sprite herb2;
    [SerializeField] private Sprite herb3;
    [SerializeField] private Sprite herb4;
    [SerializeField] private Sprite herb5;
    [SerializeField] private Sprite herb6;
    [SerializeField] private Sprite herb7;
    [SerializeField] private Sprite herb8;

    public int _isHerb = 0;

    void FixedUpdate()
    {
        if(_isHerb == 4)
        {
            _isHerb = 0;
            resultImage.sprite = null;
            resultImage2.sprite = null;
            resultImage3.sprite = null;
        }
    }

    public void ShowResult(string state)
    {
        switch (state)
        {
            case "A":
                if(_isHerb == 0)
                {
                    resultImage.sprite = herb1;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb1;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb1;
                    _isHerb++;
                }
                break;

            case "B":
                if(_isHerb == 0)
                {
                    resultImage.sprite = herb2;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb2;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb2;
                    _isHerb++;
                }
                break;

            case "C":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb3;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb3;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb3;
                    _isHerb++;
                }
                break;

            case "D":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb4;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb4;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb4;
                    _isHerb++;
                }
                break;

            case "E":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb5;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb5;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb5;
                    _isHerb++;
                }
                break;

            case "F":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb6;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb6;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb6;
                    _isHerb++;
                }
                break;

            case "G":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb7;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb7;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb7;
                    _isHerb++;
                }
                break;

            case "H":
               if(_isHerb == 0)
                {
                    resultImage.sprite = herb8;
                    _isHerb++;
                }

                else if(_isHerb == 1)
                {
                    resultImage2.sprite = herb8;
                    _isHerb++;
                }

                else if(_isHerb == 2)
                {
                    resultImage3.sprite = herb8;
                    _isHerb++;
                }
                break;
        }
    }
}
