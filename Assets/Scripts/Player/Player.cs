using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 主角脚本（测试）
/// </summary>
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraFollow();
        CheckESC();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 MoveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(MoveDirection * 5 * Time.deltaTime);
    }

    private void CameraFollow()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, 1.5f, 3f);
    }

    private void CheckESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ShowUI<PauseUI>("PauseUI");
        }
    }
}
