using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class LevelSkill : MonoBehaviour
{
    [Header("Infor")]
    public int Cost;
    public float CoolDown;
    public Skill1Enum skill1Enum;

    [Header("Images")]
    public List<ImageData> SkillImages;
    public List<ImageData> LineImages;

    public ImageType CurrentImageType;

    private SkillController skillController;

    private void Awake()
    {
        skillController = GetComponentInParent<SkillController>();
    }

    private void Start()
    {
        CurrentImageType = ImageType.NONUPGRADE;
    }

    public void OnClick()
    {
        LevelSkill currentSkill = UIManager.Instance.CurrentSkill;
        if (currentSkill != this)
        {
            if(currentSkill != null)
            {
                currentSkill.UnselectImage();
            }
            ChangeImage(ImageType.CHOOSE, SkillImages);
            MovePointer();

            UIManager.Instance.CurrentSkill = this;
            UIManager.Instance.SetInfor();
        }
    }

    public void MovePointer()
    {
        Vector3 pos = this.GetComponent<RectTransform>().anchoredPosition;
        UIManager.Instance.SetPointer(pos, skillController.gameObject.transform);
    }

    public void UnselectImage()
    {
        ChangeImage(CurrentImageType, SkillImages);
    }

    public void ChangeImage(ImageType imageType, List<ImageData> listImage)
    {
        foreach (var image in listImage)
        {
            if (image.Type == imageType)
            {
                image.Image.SetActive(true);
            }
            else image.Image.SetActive(false);
        }
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
