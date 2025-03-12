using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] private StringEvent levelGame;
    [SerializeField] private LoadGameAnim anim;

    public void levelBtnHandler(string level)
    {
        StartCoroutine(StartLevel(level));
    }

    IEnumerator StartLevel(string level)
    {
        levelGame.setUpLevel(level);
        anim.FadeAnimtion();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

}
