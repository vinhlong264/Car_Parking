using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data" , menuName = "level Data" , order = 1)]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private List<LevelSO> levels = new List<LevelSO>();
    [SerializeField] private LevelSO getLevel;

    public void GetLevel(string levelName , Transform pos)
    {
        getLevel = levels.FirstOrDefault(x => x.levelName == levelName && !x.IsCompelete);
        if (getLevel != null)
        {
            GameObject LevelSelect = Instantiate(getLevel.levelPrefabs, pos.position, Quaternion.identity);
        }
    }

    public void LevelCompelete()
    {
        if (getLevel == null) return;

        getLevel.CompeleteLevel();
    }

}
