using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [Header("Propertive")]
    

    [Header("Level")]
    public List<LevelSkill> ListLevel;
    public int CurrentLevel;
    public LevelSkill CurrentLevelSkill;

    private void Start() {
        Init();
    }

    private void Init()
    {

    }

    public void LevelUp()
    {
        CurrentLevel++;
    }
}


