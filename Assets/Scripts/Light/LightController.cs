using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 光线控制器
/// </summary>
public class LightController : MonoBehaviour
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
    public int maxReflections = 3; // 最大反射次数
    private LineRenderer lineRenderer;
    
    // 光线路径
    private List<Vector3> currentPath = new List<Vector3>();
    
    // 光线命中事件
    public delegate void LightRayHitHandler(GameObject hitObject, Vector3 hitPoint, Vector3 hitNormal);
    public static event LightRayHitHandler onLightRayHit;
    
    void Start()
    {
        myLight = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor= Color.white;
        lineRenderer.endColor= Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Brighten();
    }

    void Brighten() //长按角色发亮
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pressedTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (pressedTime < brightenTime)
            {
                Shootray();
            }
            
            pressedTime = 0;
            myLight.intensity = originalIntensity;
            myLight.range = originalRange;
        }

        if (pressedTime > brightenTime)
        {
            myLight.intensity = Mathf.Min(maxIntensity, originalIntensity + (maxIntensity - originalIntensity) / deltaTime * (pressedTime - brightenTime));
            myLight.range = Mathf.Min(maxRange, originalRange + (maxRange - originalRange) / deltaTime * (pressedTime - brightenTime));
        }
    }

    // void ray()
    // {
    //     Vector3 mousePosition = Input.mousePosition;
    //
    //     // 设置鼠标的 Z 坐标为摄像机到角色的距离
    //     mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
    //
    //     // 将鼠标位置转换为世界坐标
    //     Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //
    //     // 计算角色到鼠标的方向
    //     Vector2 direction = (worldMousePosition - transform.position).normalized;
    //
    //     // 发射射线
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, hitLayers);
    //
    //     // 设置LineRenderer的位置
    //     Vector3 endPosition = hit.collider != null ? hit.point : (Vector2)transform.position + direction * rayDistance;
    //     lineRenderer.SetPosition(0, transform.position);
    //     lineRenderer.SetPosition(1, endPosition);
    //
    //     // 短暂显示光轨迹
    //     StartCoroutine(HideLineAfterDelay(0.2f));
    // }

    void Shootray()
    {
        Vector3 mousePosition = Input.mousePosition;
        
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
        
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = (worldMousePosition - transform.position).normalized;

        // 准备绘制光线路径
        currentPath.Clear();
        currentPath.Add(transform.position);

        Ray ray = new Ray(transform.position, direction);
        
        int reflectionsLeft = maxReflections;
        
        while (reflectionsLeft >= 0)
        {
            if (Physics.Raycast(ray, out var hit, rayDistance, hitLayers))
            {
                currentPath.Add(hit.point);
                
                // 触发命中事件
                onLightRayHit?.Invoke(hit.collider.gameObject, hit.point, hit.normal);
                
                // 处理反射
                if (reflectionsLeft > 0 && hit.collider.CompareTag("Reflection"))
                {
                    // 计算反射方向
                    Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                    ray = new Ray(hit.point, reflectDir);
                    reflectionsLeft--;
                }
                // 处理折射
                else if (reflectionsLeft > 0 && hit.collider.CompareTag("Refraction"))
                {
                    
                }
                else
                {
                    // 不反射也不折射
                    // 停止
                    break;
                }
            }
            else
            {
                // 没有击中任何物体，添加终点
                currentPath.Add(ray.origin + ray.direction * rayDistance);
                break;
            }
        }

        // 更新LineRenderer
        RenderLightPath();
        // 短暂显示光轨迹
        StartCoroutine(HideLineAfterDelay(20f));
    }

    private void RenderLightPath()
    {
        lineRenderer.positionCount = currentPath.Count;
        lineRenderer.SetPositions(currentPath.ToArray());
    }
    
    IEnumerator HideLineAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lineRenderer.positionCount = 0;
        currentPath.Clear();
    }
}
