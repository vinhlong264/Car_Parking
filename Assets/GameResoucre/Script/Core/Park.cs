using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park : MonoBehaviour, IColor
{
    [SerializeField] private SpriteRenderer sr;
    public Route _route { get; private set; }

    private void Start()
    {
        _route = GetComponentInParent<Route>();
    }
    public void setColor(Color newColor)
    {
        sr.color = newColor;
    }
}
