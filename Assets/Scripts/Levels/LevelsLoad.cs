using UnityEngine;

[RequireComponent(typeof(LevelsCreate))]
public class LevelsLoad : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 0;

    private LevelsCreate _levelsCreate;
    
    public static int CurrentLevel = 0;

    private void Awake()
    {
        CurrentLevel = _currentLevel; 
    }

    private void Start()
    {
        _levelsCreate = GetComponent<LevelsCreate>();
        ActivateLevel(_currentLevel); 
    }

    private void ActivateLevel(int index)
    {
        var levels = _levelsCreate.LevelsContainer;

        if (index >= levels.Length)
            index = 0; 
        
        for (var i = 0; i < levels.Length; i++)
          levels[i].gameObject.SetActive(i == index);
    }

    public void ResetCurrentLevel()
    {
        _levelsCreate.LevelsContainer[_currentLevel].SelectObjects.ResetObject();
        _levelsCreate.LevelsContainer[_currentLevel].Platform.SetIsEmpty(true);
    }

    
    public void LoadNextLevel()
    {
        _currentLevel += 1;
        CurrentLevel = _currentLevel;
        ActivateLevel(_currentLevel);
    }
}
