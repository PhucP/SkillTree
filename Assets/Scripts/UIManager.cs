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

    [Header("Image Source")]
    public List<ImageData> ListImageSource;


    private LevelSkill _currentSkill;
    public LevelSkill CurrentSkill
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
        _description.SetText("NONE");
        _cost.SetText(_currentSkill.Cost.ToString());
        _coolDown.SetText(_currentSkill.CoolDown.ToString());
    }

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void ChangeCurrentSkill(LevelSkill skill)
    {
        _currentSkill = skill;
        SetInfor();
    }

    public void UpgradeSkill()
    {
        _currentSkill.Upgrade();
    }
}
