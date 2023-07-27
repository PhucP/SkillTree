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

    [Header("Pointer")]
    public GameObject Pointer;
    [SerializeField] private float _hight;


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

    public void SetPointer(Vector3 pos, Transform parent)
    {
        Pointer.SetActive(false);
        Pointer.transform.SetParent(parent);
        Pointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y + _hight);
        Pointer.SetActive(true);
    }
}
