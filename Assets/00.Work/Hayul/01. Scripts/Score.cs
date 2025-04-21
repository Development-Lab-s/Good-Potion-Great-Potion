using UnityEngine;
using UnityEngine.EventSystems;

public class Score : MonoBehaviour
{
    [SerializeField] private float score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Player태그를 Stick태그로 바꿀것
        {
            score++;
            if (score == 3)
            {
                //미니게임 성공 UI띄우기
            }
        }
    }
}
