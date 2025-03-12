using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] private StringEvent levelGame;
    [SerializeField] private LoadGameAnim anim;
    [SerializeField] private List<Button> buttons = new List<Button>();

    private void Start()
    {
        if (buttons.Count == 0) return;
        if (!PlayerPrefs.HasKey("LevelGame"))
        {
            Debug.Log("Key không tồn tại");
            return;
        }

        foreach(var button in buttons)
        {
            button.interactable = false;
        }

        int size = PlayerPrefs.GetInt("LevelGame");
        for(int i = 0; i <= size - 1; i++)
        {
            buttons[i].interactable = true;
        }
    }

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
