using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 主角脚本（测试）
/// </summary>
public class Player : MonoBehaviour
{
    public float smoothSpeed = 0.0125f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 MoveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(MoveDirection * 5 * Time.deltaTime);
    }

    private void CameraFollow()
    {
        Vector3 desiredPosition= new Vector3(this.transform.position.x, 1.5f,3f);
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed);
        Camera.main.transform.position = smoothedPosition;
    }

    public void EventF()
    {
        UIManager.Instance.GetUI<GameUI>("GameUI").ShowIncludeUI("event");
    }
}
