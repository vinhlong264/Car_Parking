using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park : MonoBehaviour, IColor
{
    [SerializeField] private SpriteRenderer sr;
    public Route _route { get; private set; }
    private RouteManager routeManager;
    [SerializeField] GameObject parkFX;
    private Color colorFX;

    private void Start()
    {
        _route = GetComponentInParent<Route>();
        routeManager = _route._RouteManager;
    }
    public void setColor(Color newColor)
    {
        sr.color = newColor;
        colorFX = newColor;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Car>() != null)
        {
            routeManager.OnParkEnterDestination();
            //GameObject fx = Instantiate(parkFX , transform.position , Quaternion.identity);
            //ParticleSystem.MainModule module = fx.GetComponent<ParticleSystem.MainModule>();
            //module.startColor = colorFX;
            //Destroy(fx,3f);
        }
    }
}
