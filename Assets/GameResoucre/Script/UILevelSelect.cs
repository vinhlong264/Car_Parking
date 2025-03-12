using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] private StringEvent levelGame;

    public void levelBtnHandler(string level)
    {
        StartCoroutine(StartLevel(level));
    }

    IEnumerator StartLevel(string level)
    {
        levelGame.setUpLevel(level);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

}
