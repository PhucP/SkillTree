using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillManager : MonoBehaviour
{
    public List<Skill> listSkill;
    public int skillPoint;
    public TMP_Text skillPointText;
    public static SkillManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateSkillPoint();
    }

    public void UpdateSkillPoint()
    {
        skillPointText.SetText("Skill Point: {}", skillPoint);
    }
}
