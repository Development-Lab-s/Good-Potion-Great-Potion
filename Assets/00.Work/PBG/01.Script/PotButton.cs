﻿using _00.Work.Base._02._Sprites.Manager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PotButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;
    [SerializeField] private Herb herb;
    public Button deleteButton;
    public string herbName { get; set;}
    private void Start()
    {
        TimerManager.Instance.OnTimerFinished += DeleteInHandImg;
        // 버튼에 리스너 추가
        if (deleteButton != null)
        {
            deleteButton.onClick.AddListener(DeleteTaggedObjects);
        }
    }

    private void OnDisable()
    {
        TimerManager.Instance.OnTimerFinished -= DeleteInHandImg;
    }
    

    // 지정된 태그를 가진 모든 오브젝트를 삭제하는 메소드
    public void DeleteTaggedObjects()
    {
        // 해당 태그를 가진 모든 오브젝트 찾기
        Herb[] taggedObjects = GameObject.FindObjectsByType<Herb>(FindObjectsSortMode.None);

        if (taggedObjects.Length > 0)
        {
            if (changeImageUi._isHerb != 3)
            {
                // 모든 태그된 오브젝트 삭제
                foreach (Herb obj in taggedObjects)
                {
                    herb._inHand = false;

                    changeImageUi.ShowResult(obj.data);
                    Destroy(obj.gameObject);
                }
            }
        }
    }
    
    public void DeleteInHandImg()
    {
        // 해당 태그를 가진 모든 오브젝트 찾기
        Herb[] taggedObjects = GameObject.FindObjectsByType<Herb>(FindObjectsSortMode.None);

        if (taggedObjects.Length > 0)
        {
            if (changeImageUi._isHerb != 3)
            {
                // 모든 태그된 오브젝트 삭제
                foreach (Herb obj in taggedObjects)
                {
                    herb._inHand = false;
                    Destroy(obj.gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        //리스너 제거
        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveListener(DeleteTaggedObjects);
        }
    }
}