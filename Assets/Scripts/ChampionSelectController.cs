using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChampionSelectController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] ChampionCardWidget m_ChampionCardWidgetPrefab = null;
    [SerializeField] RectTransform m_ChampionCardWidgetsHolder = null;


    [Header("Champion Info HUD")]
    [SerializeField] GameObject m_ChampionInfoHUD = null;
    [SerializeField] GameObject m_SelectChampionTooltipObject = null;
    [SerializeField] TextMeshProUGUI m_ChampionNameRef = null;
    [SerializeField] Image m_ChampionImageRef = null;
    [SerializeField] TextMeshProUGUI m_ChampionDescriptionRef = null;
    [SerializeField] Image m_ChampionEffectImageRef = null;
    [SerializeField] TextMeshProUGUI m_ChampionEffectDescriptionRef = null;
    [SerializeField] TextMeshProUGUI m_ChampionEffectNameRef = null;

    [Header("Selected Champions HUD")]
    [SerializeField] List<Image> m_SelectedChampionImagesList = new List<Image>();
    [SerializeField] Button m_StartButton = null;
    int m_SelectedIndex = 0;

    UnityEvent<ChampionInfoDataset> m_OnChampionCardHoveredEvent = new UnityEvent<ChampionInfoDataset>();
    UnityEvent<ChampionInfoDataset> m_OnChampionCardSelectedEvent = new UnityEvent<ChampionInfoDataset>();

    // Start is called before the first frame update
    void Start()
    {
        m_StartButton.interactable = false;
        m_OnChampionCardSelectedEvent.AddListener(OnChampionSelected);
        m_OnChampionCardHoveredEvent.AddListener(OnChampionCardHovered);
        m_ChampionInfoHUD.SetActive(false);
        m_SelectChampionTooltipObject.SetActive(true);
        ChampionInfoDataset[] championInfoDatasets = ResourceHelpers.FetchChampionInfoDatasets();
        foreach (ChampionInfoDataset infoDataset in championInfoDatasets)
        {
            ChampionCardWidget newWidget = Instantiate(m_ChampionCardWidgetPrefab, m_ChampionCardWidgetsHolder);
            StartCoroutine(newWidget.Initialize(infoDataset, m_OnChampionCardSelectedEvent, m_OnChampionCardHoveredEvent));
        }
    }

    void OnChampionCardHovered(ChampionInfoDataset infoDataset)
    {
        m_ChampionInfoHUD.SetActive(true);
        m_SelectChampionTooltipObject.SetActive(false);
        m_ChampionNameRef.text = infoDataset.GetChampionName();
        m_ChampionImageRef.sprite = infoDataset.GetChampionImage();
        m_ChampionDescriptionRef.text = infoDataset.GetChampionDescription();
        m_ChampionEffectImageRef.sprite = infoDataset.GetChampionEffectDataset().GetEffectImage();
        m_ChampionEffectDescriptionRef.text = infoDataset.GetChampionEffectDataset().GetEffectDescription();
        m_ChampionEffectNameRef.text = infoDataset.GetChampionEffectDataset().GetEffectName();
    }

    void OnChampionSelected(ChampionInfoDataset infoDataset)
    {
        print("Working");
        if (m_SelectedIndex == 4)
        {
            return;
        }

        Image nextEmptySlot = m_SelectedChampionImagesList[m_SelectedIndex];
        nextEmptySlot.sprite = infoDataset.GetChampionImage();
        m_SelectedIndex++;

        if (m_SelectedIndex == 4)
        {
            m_StartButton.interactable = true;
        }
    }
}
