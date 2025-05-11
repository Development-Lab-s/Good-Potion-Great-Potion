using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField]
    private float m_roughness;      //거칠기 정도
    [SerializeField]
    private float m_magnitude;      //움직임 범위

    private int _Count = 1;
    private float _cameraScale;
    private bool _canSpaceKey = true;

    private void Start()
    {
        _cameraScale = Camera.main.orthographicSize;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canSpaceKey == true)
        {
            StartCoroutine(Shake(1f));
            Camera.main.orthographicSize = Camera.main.orthographicSize - 0.5f;
            _Count++;
        }
    }

    IEnumerator Shake(float duration)
    {
        float halfDuration = duration / 2;
        float elapsed = 0f;
        float tick = Random.Range(-10f, 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime / halfDuration;

            float multifly = m_magnitude * Mathf.PingPong(elapsed, halfDuration);
            float x = Mathf.PerlinNoise(tick, 0) - .5f;
            float y = Mathf.PerlinNoise(0, tick) - .5f;
            tick += Time.deltaTime * m_roughness;
            transform.position = new Vector3(
                x * multifly,
                y * multifly,
                transform.position.z);

            yield return null;
        }
    }

    public void CameraShakeStop(bool value)
    {
        _canSpaceKey = value;
    }
}