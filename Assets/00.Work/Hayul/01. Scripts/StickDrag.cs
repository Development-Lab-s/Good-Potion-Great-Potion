using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class StickDrag : MonoBehaviour 
{ 
    public Transform ellipseCenter; // 타원의 중심
    public float radiusX = 5f; // 타원의 가로 반지름
    public float radiusY = 3f; // 타원의 세로 반지름

    public int totalCheckPoints = 6; // 총 감지하는 콜라이더의 개수
    public int requiredRotations = 3; // 성공 조건 : 올바른 방향으로 3바퀴 돌려야 함
    public List<int> indexs = new List<int>(); // id 저장하는 리스트
    public UISystemManager uISystemManager;

    private int counterRotationCounts = 0; //역방향 환료된 바퀴 수 세기
    private int currentRotationCounts = 0; // 완료된 시계방향 바퀴 개수 세기
    private bool success = false; // 완료 감지

    //숫자로 표기하기 애매한 거 표시함
    public enum RotationDirection
    {
        None = 0,
        Clockwise = 1,
        CounterClockwise = 2
    }

    public RotationDirection lastDirection = RotationDirection.None;

    public void OnCheckPointTrigger(int id)
    {
        if (success) return;

        //중복 방지 로직
        if (indexs.Count > 1 && indexs[indexs.Count - 1] == id)
        {
            Debug.Log("중복이에요");
            return;
        }

        indexs.Add(id);

        if (indexs.Count == totalCheckPoints -1)
        {
            if (IsSequnetialAndClockwise(indexs, true)) // 정방향
            {
                currentRotationCounts++; // 정방향으로 돌았으면 1바퀴 카운트
                Debug.Log("한바퀴를 다 돌았습니다(시계방향)");

                if (currentRotationCounts >= requiredRotations)
                {

                    if (uISystemManager.currentDirection != RotationDirection.CounterClockwise)
                    {
                        success = true; //3바퀴 다 돌렸으면 끝내기
                        Debug.Log("3바퀴를 다 돌았습니다(시계방향)");
                        //돌려야 했던 방향 확인
                        OnSuccess(RotationDirection.Clockwise);
                    }

                    else
                        DeSuccess();
                }
                else if ((counterRotationCounts + currentRotationCounts) >= requiredRotations)
                {
                    DeSuccess();
                }
            }
            else if (IsSequnetialAndClockwise(indexs, false)) //역방향
            {
                counterRotationCounts++; //역방향으로 돌았으면 1바퀴 카운트
                Debug.Log("한바퀴를 다 돌았습니다(반시계방향)");

                if (counterRotationCounts >= requiredRotations)
                {
                    if (uISystemManager.currentDirection != RotationDirection.CounterClockwise)
                    {
                        success = true; //3바퀴 다 돌렸으면 끝내기
                        Debug.Log("3바퀴를 다 돌았습니다(반시계방향)");
                        //돌려야 했던 방향 확인
                        OnSuccess(RotationDirection.CounterClockwise);
                    }
                    else
                        DeSuccess();
                }
                else if ((counterRotationCounts + currentRotationCounts) >= requiredRotations) 
                {
                    DeSuccess();
                }
            }
            indexs.Clear();
        }
    }

    public void OnSuccess(RotationDirection direction)
    {
        Debug.Log($"성공 방향: {direction}, 시계방향: {currentRotationCounts}, 반시계방향: {counterRotationCounts}");
    }

    public void DeSuccess()
    {
        Debug.Log($"실패하였습니다! 돌려야 했던 방향: {uISystemManager.currentDirection}, " +
            $"시계방향: {currentRotationCounts}, 반시계방향: {counterRotationCounts}");
    }

    private bool IsSequnetialAndClockwise(List<int> ids, bool clockwise)
    {
        for (int i = 0; i < ids.Count -1; i++)
        {
            int expected = clockwise ? 
                // 정방향 계산
                (ids[0] + i) % totalCheckPoints : 
                // 역방향 계산
                (ids[0] - i) % totalCheckPoints;
            if (ids[i] != expected)
            {
                return false; // 리스트 값과 다르다면 실패
            }
        }
        return true; // 만약 리스트값 맞으면 성공
    }

    
    //다른 곳에서 가져오고 싶을 때
    public int GetClockwiseCount() => currentRotationCounts;
    public int GetConterClockwiseCount() => counterRotationCounts;
    public RotationDirection GetRotationDirection() => lastDirection;

    void OnMouseDrag() 
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z; // Z 고정

        // 중심 기준으로 상대 위치 계산
        Vector2 localPos = mouseWorldPos - ellipseCenter.position;

        // 타원 안에 있는지 검사
        float normalizedX = localPos.x / radiusX;
        float normalizedY = localPos.y / radiusY;
        float distanceFromCenter = normalizedX * normalizedX + normalizedY * normalizedY;

        if (distanceFromCenter > 1f)
        {
            // 타원 밖에 있으면 타원 경계로 위치 보정
            float angle = Mathf.Atan2(localPos.y / radiusY, localPos.x / radiusX);
            localPos = new Vector2(Mathf.Cos(angle) * radiusX, Mathf.Sin(angle) * radiusY);
        }

        // 최종 위치 적용
        transform.position = ellipseCenter.position + (Vector3)localPos;
    }

    public int segments = 64; // 타원을 구성할 선분 수

    void OnDrawGizmos()
    {
        if (ellipseCenter == null) return;

        Gizmos.color = Color.green;

        Vector3 prevPoint = Vector3.zero;
        for (int i = 0; i <= segments; i++)
        {
            float angle = (i / (float)segments) * Mathf.PI * 2f;
            float x = Mathf.Cos(angle) * radiusX;
            float y = Mathf.Sin(angle) * radiusY;

            Vector3 currentPoint = ellipseCenter.position + new Vector3(x, y, 0f);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPoint, currentPoint);
            }
            prevPoint = currentPoint;
        }
    }
}
