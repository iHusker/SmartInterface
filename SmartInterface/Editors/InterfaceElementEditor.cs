using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using SmartInterface.Elements;

namespace SmartInterface.Editors 
{
    [CustomEditor(typeof(InterfaceElement))]
    [CanEditMultipleObjects]
    class InterfaceElementEditor : Editor
    {
        void OnEnable()
        {
            InterfaceElement targetCast = (target as InterfaceElement);
            targetCast.hideFlags = HideFlags.HideInInspector;

            //Hide Canvas Group
            CanvasGroup canvasGroup = targetCast.GetComponent<CanvasGroup>();
            if (canvasGroup != null) canvasGroup.hideFlags = HideFlags.HideInInspector;

            //Hide Canvas Renderer
            CanvasRenderer canvasRenderer = targetCast.GetComponent<CanvasRenderer>();
            if (canvasRenderer != null) canvasRenderer.hideFlags = HideFlags.HideInInspector;

            //Hide Rectangle Transform
            RectTransform rectTransform = targetCast.GetComponent<RectTransform>();
            if (rectTransform != null) rectTransform.hideFlags = HideFlags.HideInInspector;

            //Hide Image
            Image image = targetCast.GetComponent<Image>();
            if (image != null) image.hideFlags = HideFlags.HideInInspector;
        }
    }
}
