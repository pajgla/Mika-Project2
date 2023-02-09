using UnityEngine;
using TMPro;

public class PanelResizer : MonoBehaviour
{
    [SerializeField]
    private float paddingTop = 0f;

    [SerializeField]
    private float paddingLeft = 0f;

    public void Update()
    {
        RectTransform panelTransform = GetComponent<RectTransform>();
        // Find the TextMeshPro component as a child of the panel
        TextMeshProUGUI textMeshPro = panelTransform.GetComponentInChildren<TextMeshProUGUI>();

        // Calculate the size of the text
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        // Update the size of the panel to match the size of the text
        panelTransform.sizeDelta = new Vector2(panelTransform.sizeDelta.x + paddingLeft, textSize.y + paddingTop);
    }
}