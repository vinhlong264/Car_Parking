using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public LineDrawer lineDrawer;

    private List<Route> routes = new List<Route>();
    private int totalRoute;
    private int carToDestination;

    private void Start()
    {
        totalRoute = GetComponentsInChildren<Route>().Length;
        lineDrawer = GameManager.Instance.lineDrawer;
    }

    public void OnParkEnterDestination()
    {
        carToDestination++;
        if(carToDestination == routes.Count)
        {
            Debug.Log("You win");
        }
    }

    public void RegisterRoute(Route _route) // đăng kí các route điều khiển car
    {
        routes.Add(_route);
        if (routes.Count == totalRoute)
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
