using UnityEngine;

public class FanDou : MonoBehaviour
{
    // 砂石颗粒的预制体
    public GameObject sandGrainPrefab;
    // 要生成的砂石颗粒数量
    public int grainCount = 10;
    // 砂石堆的半径范围
    public float pileRadius = 2f;
    public float lowDrag = 0.1f;         // 减小空气阻力
    public float destroyDelay = 20f; // 20秒后销毁
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("检测到 other: " + other.name);
        if(other.name == "Obj3d66-1744977-31-407") {
            // 循环生成指定数量的砂石颗粒
            for(int i = 0; i < grainCount; i++)
            {
                // 计算随机位置:
                // 1. 以当前对象位置为中心
                // 2. 在单位球内随机一个点
                // 3. 乘以半径范围
                // 4. 将y轴设为当前对象y位置(确保颗粒从同一高度开始下落)
                Vector3 pos = transform.position + Random.insideUnitSphere * pileRadius;
                pos.y = transform.position.y;
                
                // 实例化砂石颗粒预制体
                var grain = Instantiate(sandGrainPrefab, pos, Quaternion.identity);

                // 随机缩放
                float scale = Random.Range(1f, 1.5f);
                grain.transform.localScale = Vector3.one * scale;
                Rigidbody rb = grain.GetComponent<Rigidbody>();
                rb.linearDamping = lowDrag;       // 减少阻力使下落更快
                rb.angularDamping = 0.05f;  // 减少旋转阻力

                // 20秒后销毁
                Destroy(grain, destroyDelay);
            }
        }
       
    }
}
