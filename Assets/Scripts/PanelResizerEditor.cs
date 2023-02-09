using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PanelResizer))]
public class PanelResizerEditor : Editor
{
    private void OnSceneGUI()
    {
        base.OnInspectorGUI();

        PanelResizer panelResizer = (PanelResizer)target;
        panelResizer.Update();
    }
}