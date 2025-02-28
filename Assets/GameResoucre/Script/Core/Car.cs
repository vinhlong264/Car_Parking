using DG.Tweening;
using UnityEngine;
public class Car : MonoBehaviour, IColor
{
    private Rigidbody rb;
    public Route _route { get; private set; }

    private void Start()
    {
        _route = GetComponentInParent<Route>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMoveCar(Vector3[] path)
    {

        for (int i = 0; i < path.Length; i++)
        {
            path[i].y = transform.position.y;   
        }

        rb.DOPath(path , 1f , PathType.CatmullRom)
            .SetLookAt(0.01f, false).
            SetEase(Ease.Linear);

        //DoPath(path, 1.5f , PathType.CatmullRoom)
        //+) path: mảng chứa các điểm di chuyển
        //+) duration(1.5f): Thời gian di chuyển hết các điểm
        //+) PathType: kiểu path để gameObject di chuyển

        //SetLookAt(0.01f,false)
        //+)  lookAtHead(0.01f) : Tỉ lệ khoảng cách để tính hướng
        //+) stableZRotation: có giữ nguyên trục Z không
    }


    public void setColor(Color newColor)
    {
        
    }
}
