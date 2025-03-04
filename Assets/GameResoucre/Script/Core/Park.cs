using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Park : MonoBehaviour, IColor
{
    [SerializeField] private SpriteRenderer sr;
    public Route _route { get; private set; }
    private RouteManager routeManager;
    [SerializeField] private GameObject fxPark;
    [SerializeField] private Transform posFx;
    
    private Color colorFx;

    private void Start()
    {
        _route = GetComponentInParent<Route>();


        routeManager = _route._RouteManager;
    }
    public void setColor(Color newColor)
    {
        sr.color = newColor;
        colorFx = newColor;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Car>() != null)
        {
            fxParkHandler();
            routeManager.OnParkEnterDestination();
        }
    }

    private void fxParkHandler()
    {
        GameObject fx = Instantiate(fxPark, posFx.position, transform.rotation);
        fx.GetComponent<SpriteRenderer>().color = colorFx;
    }
}
