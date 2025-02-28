using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LineDrawer lineDrawer;
    
    private List<Route> routes = new List<Route>();
    private int totalRoute;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        totalRoute = GetComponentsInChildren<Route>().Length;
    }


    public void RegisterRoute(Route _route)
    {
        routes.Add(_route);
        if(routes.Count == totalRoute)
        {
            MoveAllCars();
        }
    }

    private void MoveAllCars()
    {
        foreach (var i in routes)
        {
            i.Car.OnMoveCar(i.points.ToArray());
        }
    }

}
