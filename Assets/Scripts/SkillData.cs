using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillTree/SkillData", order = 0)]
public class SkillData : ScriptableObject
{
    public List<SkillController> DataSkill;
}
