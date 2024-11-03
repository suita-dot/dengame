using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Movedistance = 1.0f;
    public float Moveduration = 0.3f;
    public LayerMask obstacleMask; // 障害物用のレイヤー

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Move(Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Move(Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(Move(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(Move(Vector3.left));
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction * Movedistance;

        // 障害物チェック
        if (Physics.Raycast(transform.position, direction, Movedistance, obstacleMask))
        {
            transform.position = startPosition;
            yield break; // 障害物がある場合、移動を中止
        }

        float elapsedTime = 0f;

        while (elapsedTime < Moveduration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / Moveduration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最終位置を設定
        transform.position = targetPosition;
    }
}

