using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Config")]
    public List<Skill> listSkill;


    [Header("Reference")]
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _coolDown;
    [SerializeField] private Button _upgrade;


    private Skill _currentSkill;
    public Skill CurrentSkill
    {
        get => _currentSkill;
        set => _currentSkill = value;
    }

    private void Awake()
    {
        Singleton();
        Init();
    }

    private void Init()
    {

    }

    public void SetInfor()
    {
        _description.SetText(_currentSkill.description);
        _cost.SetText(_currentSkill.cost.ToString());
        _coolDown.SetText(_currentSkill.coolDoown.ToString());
    }

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void ChangeCurrentSkill(Skill skill)
    {
        if(_currentSkill != null) _currentSkill._pointer.SetActive(false);
        _currentSkill = skill;
        SetInfor();
    }
}
