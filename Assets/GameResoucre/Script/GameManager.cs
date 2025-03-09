using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public LineDrawer lineDrawer;

    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField] private Transform SpawnPos;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            levelDataSO.GetLevel("Level 1", SpawnPos);
        }
    }

    public void OnYouLose()
    {
        Debug.Log("You lose");
    }
}
