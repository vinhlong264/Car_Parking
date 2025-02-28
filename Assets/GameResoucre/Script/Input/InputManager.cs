using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IDrawHandler drawHandler;
    private void Start()
    {
        drawHandler = GetComponent<IDrawHandler>();
    }

    private void Update()
    {
        
    }

    private void InputWindowHandler()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            drawHandler.OnBeginDrawHandler();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            drawHandler.OnDrawHandler();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            drawHandler.OnEndDrawHandler();
        }
    }
}

[System.Serializable]
public class RaycastDectector
{
    private LayerMask whatIsMask;
    public struct RaycastInfor
    {
        public bool isContact;
        public Vector3 point;
        public Transform transform;
        public Collider colider;
    }

    public RaycastDectector(LayerMask _mask)
    {
        this.whatIsMask = _mask;
    }

    public RaycastInfor GetInforRaycast()
    {
        Ray ray = new Ray();

        if(Application.platform == RuntimePlatform.WindowsEditor ||  Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            Touch touch = new Touch();
            ray = Camera.main.ScreenPointToRay(touch.position);
        }



        bool hitPoint = Physics.Raycast(ray, out RaycastHit hitInfor, float.PositiveInfinity, whatIsMask);

        return new RaycastInfor
        {
            isContact = hitPoint,
            point = hitInfor.point,
            transform = hitInfor.transform,
            colider = hitInfor.collider
        };
    }
}
