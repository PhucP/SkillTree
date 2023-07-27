using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class LevelSkill : MonoBehaviour, IPointerClickHandler
{
    [Header("Infor")]
    public int Cost;
    public float CoolDown;

    [Header("Images")]
    public List<ImageData> SkillImages;
    public List<ImageData> LineImages;

    private SkillController skillController;

    private void Awake()
    {
        skillController = GetComponentInParent<SkillController>();
    }

    private void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.CurrentSkill = this;
        ChangeImage(ImageType.CHOOSE);
    }

    public void ChangeImage(ImageType imageType)
    {
        
    }

    private GameObject GetImage(List<ImageData> listImage, ImageType imageType)
    {
        return listImage.FirstOrDefault(image => image.Type == imageType).Image;
    }

    public void Upgrade()
    {

    }

}

[System.Serializable]
public enum Skill1Enum
{
    LV1,
    LV2,
    LV3
}
[System.Serializable]
public class ImageData
{
    public GameObject Image;
    public ImageType Type;
}

[System.Serializable]
public enum ImageType
{
    UPGRADED,
    NONUPGRADE,
    CHOOSE
}
