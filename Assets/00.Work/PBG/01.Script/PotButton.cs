using UnityEngine;
using UnityEngine.UI;

public class PotButton : MonoBehaviour
{
    private string targetTag = "Herb";
    public Button deleteButton;

    private void Start()
    {
        // 버튼에 리스너 추가
        if (deleteButton != null)
        {
            deleteButton.onClick.AddListener(DeleteTaggedObjects);
        }
    }

    // 지정된 태그를 가진 모든 오브젝트를 삭제하는 메소드
    public void DeleteTaggedObjects()
    {
        // 해당 태그를 가진 모든 오브젝트 찾기
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        
        if (taggedObjects.Length > 0)
        {
            // 모든 태그된 오브젝트 삭제
            foreach (GameObject obj in taggedObjects)
            {
                Destroy(obj);
            }
        }
    }

    private void OnDestroy()
    {
        // 메모리 누수 방지를 위한 리스너 제거
        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveListener(DeleteTaggedObjects);
        }
    }
}