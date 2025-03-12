using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private SpawnLevel spawnLevel;

    public void PlayBtnHandler(GameObject active)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (active != null)
        {
            active.SetActive(true);
        }
    }

    public void ExitLevelSelectHandler(GameObject active)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        active.SetActive(false);
    }

    public void OnNextLevelBtn(GameObject setlf)
    {
        if (spawnLevel == null) return;

        setlf.SetActive(false);

        StartCoroutine(DelayEvent(() =>
        {
            spawnLevel.NextLevel();
        }));
    }

    IEnumerator DelayEvent(System.Action action = null)
    {
        yield return new WaitForSeconds(1f);
        action?.Invoke();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGameHandler()
    {
        Application.Quit();
    }

    public void OnResetGameBtn(GameObject self)
    {
        GameManager.Instance.OnResetGameInvoke();
        self.SetActive(false);
    }
}
