using UnityEngine;
using UnityEngine.UI;

public class PotButton : MonoBehaviour
{
    [Tooltip("삭제할 오브젝트의 태그")]
    private string targetTag = "Herb";
    
    [Tooltip("삭제 버튼")]
    public Button deleteButton;

    private void Start()
    {
        // 버튼에 리스너 추가
        if (deleteButton != null)
        {
            deleteButton.onClick.AddListener(DeleteTaggedObjects);
        }
        else
        {
            Debug.LogError("삭제 버튼이 할당되지 않았습니다. Inspector에서 버튼을 할당해주세요.");
        }
    }

    // 지정된 태그를 가진 모든 오브젝트를 삭제하는 메소드
    public void DeleteTaggedObjects()
    {
        // 해당 태그를 가진 모든 오브젝트 찾기
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        
        if (taggedObjects.Length > 0)
        {
            Debug.Log($"{targetTag} 태그가 있는 {taggedObjects.Length}개의 오브젝트를 삭제합니다.");
            
            // 모든 태그된 오브젝트 삭제
            foreach (GameObject obj in taggedObjects)
            {
                Destroy(obj);
            }
        }
        else
        {
            Debug.Log($"{targetTag} 태그를 가진 오브젝트가 없습니다.");
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