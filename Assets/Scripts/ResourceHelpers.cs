using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceHelpers
{
    public static ChampionInfoDataset[] FetchChampionInfoDatasets()
    {
        return Resources.LoadAll<ChampionInfoDataset>("Champions/ChampionInfoDatasets");
    }
}
