using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using SmartInterface.Elements;

namespace SmartInterface.Menus
{
    class InterfaceMenu : MonoBehaviour
    {
        [MenuItem("Smart Interface/Create/Group")]
        static void CreateGroup()
        {
            GameObject @object = new GameObject("Interface Group");
            @object.AddComponent<InterfaceGroup>();
            @object.AddComponent<InterfaceAnimation>();
            @object.AddComponent<RectTransform>();

            Canvas canvas = FindObjectOfType<Canvas>();
            if(canvas) @object.transform.SetParent(canvas.transform);
        }

        [MenuItem("Smart Interface/Create/Empty", true, 0)]
        static void CreateElement()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Empty");
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();
            @object.AddComponent<InterfaceAnimation>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            } 
        }

        [MenuItem("Smart Interface/Create/Button", false, 0)]
        static void CreateButton()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Button");
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<InterfaceAnimation>();
            @object.AddComponent<Image>();
            @object.AddComponent<Button>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }

        [MenuItem("Smart Interface/Create/Slider")]
        static void CreateSlider()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Slider");
            @object.AddComponent<Slider>();
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }


        [MenuItem("Smart Interface/Create/Drop Down")]
        static void CreateDropDown()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Drop Down");
            @object.AddComponent<Dropdown>();
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }

        [MenuItem("Smart Interface/Create/Image")]
        static void CreateImage()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Image");
            @object.AddComponent<Image>();
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<CanvasGroup>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }

        [MenuItem("Smart Interface/Create/Toggle")]
        static void CreateToggle()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Toggle");
            @object.AddComponent<Toggle>();
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }


        [MenuItem("Smart Interface/Create/Text")]
        static void CreateText()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Text");
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();

            Text text = @object.AddComponent<Text>();
            text.text = "New Text";

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }

        [MenuItem("Smart Interface/Create/Scroll Bar")]
        static void CreateScrollbar()
        {
            Object[] interfaceGroups = FindObjectsOfType(typeof(InterfaceGroup));

            GameObject @object = new GameObject("Scroll Bar");
            @object.AddComponent<Scrollbar>();
            @object.AddComponent<InterfaceElement>();
            @object.AddComponent<InterfaceAnimation>();
            @object.AddComponent<RectTransform>();
            @object.AddComponent<CanvasGroup>();

            if (interfaceGroups.Length > 0)
            {
                InterfaceGroup interfaceGroup = interfaceGroups[interfaceGroups.Length - 1] as InterfaceGroup;
                @object.transform.SetParent(interfaceGroup.transform, false);
                interfaceGroup.Build();
            }
        }


        [MenuItem("Smart Interface/Destroy All")]
        static void DestroyAll()
        {
            foreach(InterfaceGroup interfaceGroup in FindObjectsOfType(typeof(InterfaceGroup))) {
                DestroyImmediate(interfaceGroup);
            }
        }
    }
}
