using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Champion Effect Info Dataset", menuName = "Champions/New Champion Effect Dataset")]
public class ChampionEffectInfoDataset : ScriptableObject
{
    //UI Info
    [SerializeField] Sprite m_EffectImage = null;
    [SerializeField] string m_EffectName = "";
    [SerializeField, TextArea(3,5)] string m_EffectDescription = "";

    //Gameplay Info ...


    public Sprite GetEffectImage() { return m_EffectImage; }
    public string GetEffectName() { return m_EffectName; }
    public string GetEffectDescription() { return m_EffectDescription; }
}
