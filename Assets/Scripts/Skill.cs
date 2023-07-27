using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public List<ImageData> ListImage;
    public string tile;
    public string description;
    public int cost;
    public int maxUpgrade;
    public int level;
    public List<Skill> listSkillConnect;
    public Skill PreviousSkill;
    public bool IsUpgraded;
    public bool isActive;
    public float coolDoown;

    [SerializeField] private TMP_Text _skillTile;
    [SerializeField] private TMP_Text _skillDescription;
    [SerializeField] private Transform lines;
    public GameObject _pointer;

    private Image sprite;

    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isActive = false;
        level = 0;
        IsUpgraded = false;

        ChangeSkillTile();
    }


    public void Upgrade()
    {
        if (SkillManager.Instance.skillPoint <= 0 || level >= maxUpgrade) return;

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

    public void UpgradeInPlayScene()
    {
        if (level >= maxUpgrade) return;

        if (PreviousSkill == null || PreviousSkill.IsUpgraded)
        {
            level++;
            IsUpgraded = true;
        }
    }

    public void ChangeSkillTile()
    {
        if (!IsPlayScene()) return;

        string process = level + "/" + maxUpgrade + " " + tile;
        _skillTile.SetText(process);
        _skillDescription.SetText("Description of " + tile);
    }

    private bool IsPlayScene()
    {
        if (_skillDescription == null || _skillTile == null)
            return false;
        return true;
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

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     UIManager.Instance.ChangeCurrentSkill(this);
    //     if (!_pointer.activeInHierarchy)
    //     {
    //         _pointer.SetActive(true);
    //         sprite.sprite = GetSprite(ImageType.CHOOSE);
    //     }
    // }

    private Sprite GetSprite(ImageType imageType)
    {
        // var imageData = ListImage.FirstOrDefault(image => image.Type == imageType);
        // return imageData.Image;
        return null;
    }
}

