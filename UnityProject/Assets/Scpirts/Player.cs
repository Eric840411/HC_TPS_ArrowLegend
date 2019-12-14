using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"),Range(1,100)]
    public float speed = 20;

    private Joystick joy;
    private Transform target;
    private Rigidbody rig;

    private void Start()
    {
        // 剛體欄位 = 取得元件<泛型>()
        rig = GetComponent<Rigidbody>();
        target = GameObject.Find("目標").GetComponent<Transform>();
        //target = GameObject.Find("目標").Transform; 第二種寫法
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
    }

    //固定更新; 固定一秒50次,物理行為
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動玩家方法
    /// </summary>
    private void Move()
    {
        float h = joy.Horizontal; //虛擬搖桿水平
        float v = joy.Vertical;   //虛擬搖桿垂直
        rig.AddForce(h * -speed, 0, v * -speed); //剛體. 增加推力(水平,0,垂直)

        //取得此物件變型元件
        //原寫 : GetComponet<Transform>()
        //簡寫 : Transform

        Vector3 posPlayer = transform.position;                               //玩家座標 = 取得玩家.座標
        Vector3 posTarget = new Vector3(posPlayer.x + h, 0, posPlayer.z + v); //目標座標 = 新 三維向量(玩家.x + 搖桿.x , 0 , 玩家.z + 搖桿.z)

        target.position = posTarget;                                          //目標.座標 = 目標座標
    }
}
