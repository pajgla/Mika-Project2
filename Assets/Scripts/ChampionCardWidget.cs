using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class ChampionCardWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] TMPro.TextMeshProUGUI m_ChampionNameTextRef = null;
    [SerializeField] Image m_ChampionImageRef = null;
    [SerializeField] TMPro.TextMeshProUGUI m_EffectNameRef = null;
    [SerializeField] Image m_EffectImageRef = null;

    [Header("Tweaking")]
    [SerializeField] float m_PositionMoveOnHover = 10.0f;
    [SerializeField] float m_AnimationDuration = 0.3f;

    float m_DefaultAnchoredYPosition = 0.0f;

    UnityEvent<ChampionInfoDataset> m_OnSelectedCallback = null;
    UnityEvent<ChampionInfoDataset> m_OnHoveredCallback = null;
    ChampionInfoDataset m_ChampionInfoDataset = null;

    public IEnumerator Initialize(ChampionInfoDataset infoDataset, UnityEvent<ChampionInfoDataset> onSelectedCallback, UnityEvent<ChampionInfoDataset> onHoveredCallback)
    {
        //Wait for the end of the frame because Layout is still updating when we Instantiate our widget
        yield return new WaitForEndOfFrame();

        ChampionEffectInfoDataset effectInfoDataset = infoDataset.GetChampionEffectDataset();
        m_ChampionNameTextRef.text = infoDataset.GetChampionName();
        m_ChampionImageRef.sprite = infoDataset.GetChampionImage();
        m_EffectImageRef.sprite = effectInfoDataset.GetEffectImage();
        m_EffectNameRef.text = effectInfoDataset.GetEffectName();

        RectTransform rectTransformComponent = GetComponent<RectTransform>();
        m_DefaultAnchoredYPosition = rectTransformComponent.anchoredPosition.y;

        m_OnSelectedCallback = onSelectedCallback;
        m_OnHoveredCallback = onHoveredCallback;
        m_ChampionInfoDataset = infoDataset;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        RectTransform rectTransformComponent = GetComponent<RectTransform>();
        rectTransformComponent.DOAnchorPosY(m_DefaultAnchoredYPosition + m_PositionMoveOnHover, m_AnimationDuration);
        m_OnHoveredCallback.Invoke(m_ChampionInfoDataset);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RectTransform rectTransformComponent = GetComponent<RectTransform>();
        rectTransformComponent.DOAnchorPosY(m_DefaultAnchoredYPosition, m_AnimationDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnSelectedCallback.Invoke(m_ChampionInfoDataset);
    }
}
