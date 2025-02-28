using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private LineRender _lineRender;
    [SerializeField] private Park _park;

    [Header("Color infor")]
    [SerializeField] private Color _lineColor;

    private LineDrawer _lineDrawer;
    public List<Vector3> points { get; private set; }
    
    public Car Car { get => _car; }
    public LineRender LineRender { get => _lineRender; }


    void Start()
    {
        _lineDrawer = GameManager.Instance.lineDrawer;

        _lineDrawer.OnParkLinked += OnParkLinkedHandler;
    }

    private void OnParkLinkedHandler(Route route , List<Vector3> path)
    {
        if(path.Count == 0 || route != this) return;
        points = path;
        GameManager.Instance.RegisterRoute(this);
    }

#if UNITY_2022_3
    private void OnDrawGizmos()
    {
        _lineRender.setColor(_lineColor);
    }
#endif
}
