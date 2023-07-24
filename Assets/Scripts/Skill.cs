using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skill : MonoBehaviour
{
    public string tile;
    public string description;
    public int cost;
    public int maxUpgrade;
    public int level;
    public List<Skill> listSkillConnect;
    public bool isActive;

    [SerializeField] private TMP_Text _skillTile;
    [SerializeField] private TMP_Text _skillDescription;
    [SerializeField] private Transform lines;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isActive = false;
        level = 0;

        ChangeSkillTile();
    }


    public void Upgrade()
    {
        if(SkillManager.Instance.skillPoint <= 0 || level >= maxUpgrade) return;

        level++;
        SkillManager.Instance.skillPoint--;
        SkillManager.Instance.UpdateSkillPoint();
        isActive = true;

        if (listSkillConnect == null) return;
        foreach (var skill in listSkillConnect)
        {
            skill.isActive = true;
            skill.gameObject.SetActive(true);

            CreateLineRendererToSkill(skill.transform);
        }

        ChangeSkillTile();
    }

    public void ChangeSkillTile()
    {
        string process = level + "/" + maxUpgrade + " " + tile;
        _skillTile.SetText(process);
        _skillDescription.SetText("Description of " + tile);
    }

    private void CreateLineRendererToSkill(Transform targetSkill)
    {
        GameObject temp = new GameObject();
        temp.transform.SetParent(lines);
        temp.name = "line";

        LineRenderer lineRenderer = temp.GetComponent<LineRenderer>();
        if (!lineRenderer)
        {
            lineRenderer = temp.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.material = new Material(Shader.Find("Standard"));
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetSkill.position);
    }
}