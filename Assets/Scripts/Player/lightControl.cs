using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour
{
    Light myLight;
    private float pressedTime;
    public float brightenTime = 0.5f;//按压0.5f后开始发亮
    public float deltaTime = 0.5f;//0.5f内光强和范围逐渐变大

    public float originalRange = 3f;
    public float maxRange = 4f;
    public float originalIntensity = 2f;
    public float maxIntensity = 2.5f;

    public float rayDistance = 10f;
    public LayerMask hitLayers;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2; // 光
        lineRenderer.startColor= Color.white;
        lineRenderer.endColor= Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Brighten();
    }

    void Brighten()//长按角色发亮
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pressedTime+=Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (pressedTime < brightenTime)
            {
                ray();
            }
            pressedTime=0;
            myLight.intensity=originalIntensity;
            myLight.range=originalRange;
        }

        if (pressedTime > brightenTime)
        {
            myLight.intensity = Mathf.Min(maxIntensity, originalIntensity + (maxIntensity - originalIntensity) / deltaTime * (pressedTime - brightenTime));
            myLight.range = Mathf.Min(maxRange, originalRange + (maxRange - originalRange) / deltaTime * (pressedTime - brightenTime));
        }
    }

    void ray()
    {
        Vector3 mousePosition = Input.mousePosition;

        // 设置鼠标的 Z 坐标为摄像机到角色的距离
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);

        // 将鼠标位置转换为世界坐标
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 计算角色到鼠标的方向
        Vector2 direction = (worldMousePosition - transform.position).normalized;

        // 发射射线
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, hitLayers);

        // 设置LineRenderer的位置
        Vector3 endPosition = hit.collider != null ? hit.point : (Vector2)transform.position + direction * rayDistance;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);

        // 短暂显示光轨迹
        StartCoroutine(HideLineAfterDelay(0.2f));
    }
    IEnumerator HideLineAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
