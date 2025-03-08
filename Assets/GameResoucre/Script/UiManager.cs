using UnityEngine;

public class UiManager : MonoBehaviour
{

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

    public void ExitGameHandler()
    {
        Application.Quit();
    }
}
