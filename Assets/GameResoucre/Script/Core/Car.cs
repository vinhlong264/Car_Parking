using System.Collections;
using UnityEngine;
public class Car : MonoBehaviour, IColor
{
    private Rigidbody rb;
    public Route _route { get; private set; }
    [SerializeField] private int index;
    [SerializeField] private float duration;
    [SerializeField] private bool isCollision;
    [SerializeField] private ParticleSystem fxCarCollision;

    private void Start()
    {
        _route = GetComponentInParent<Route>();
        rb = GetComponent<Rigidbody>();
        isCollision = false;
    }

    public void OnMoveCar(Vector3[] path)
    {

        for (int i = 0; i < path.Length; i++)
        {
            path[i].y = transform.position.y;
        }

        StartCoroutine(MoveCar(path));
    }

    IEnumerator MoveCar(Vector3[] path)
    {
        while (index < path.Length && !isCollision)
        {
            Vector3 startPos = transform.position;  //cập nhập điểm bắt đầu
            Vector3 endPos = path[index];           // Cập nhật điểm kết thúc

            Vector3 dir = (endPos - transform.position).normalized;
            float t = 0;
            while (t < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, t/duration);
                t += Time.deltaTime;
                yield return null;
            }
            
            transform.rotation = Quaternion.LookRotation(dir);
            transform.position = endPos;
            index++;
            yield return null; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ColisionHandler(collision.GetContact(0).point);
        }
    }

    private void ColisionHandler(Vector3 hitDir)
    {
        GameManager.Instance.OnYouLose();


        rb.AddExplosionForce(100, hitDir, 3f);
        rb.AddForceAtPosition(Vector3.up * 5f , hitDir , ForceMode.Impulse);
        rb.AddTorque(GetRandomDir(), GetRandomDir(), GetRandomDir());
        isCollision = true;
        fxCarCollision.Play();
    }

    private float GetRandomDir()
    {
        float angle = 20f;
        float rand = Random.value;

        return rand < 0.5f ? angle : -angle;
    }


    public void setColor(Color newColor)
    {

    }
}
