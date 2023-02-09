using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Champion Info Dataset", menuName = "Champions/New Champion Info Dataset")]
public class ChampionInfoDataset : ScriptableObject
{
    //UI Info
    [SerializeField] Sprite m_ChampionImage = null;
    [SerializeField] string m_ChampionName = "";
    [SerializeField, TextArea(5, 7)] string m_ChampionDescription = "";
    [SerializeField] ChampionEffectInfoDataset m_ChampionEffectDataset = null;
    //Gameplay Info ..


    public Sprite GetChampionImage() { return m_ChampionImage;}
    public string GetChampionName() { return m_ChampionName;}
    public string GetChampionDescription() { return m_ChampionDescription;}
    public ChampionEffectInfoDataset GetChampionEffectDataset() { return m_ChampionEffectDataset;}
}
