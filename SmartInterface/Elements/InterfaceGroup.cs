using System.Collections.ObjectModel;
using System;

using UnityEngine;
using System.Reflection;

namespace SmartInterface.Elements
{
    [AddComponentMenu("SmartInterface/InterfaceGroup")]
    public class InterfaceGroup : MonoBehaviour
    {
        public enum Layout
        {
            GRID,
            HORIZONTAL,
            VERTICAL
        }

        public Layout layout = Layout.GRID;
        public Vector2 origin = Vector2.zero;

        public bool flipX;
        public bool flipY;

        public int cellSize = 3;
        public float animationInterval = 1.0f;

        public Vector2 dimension = new Vector2(100.0f, 100.0f);
        public Vector2 margin = Vector2.zero;
        public Vector2 scale = new Vector2(1.0f, 1.0f);
        public Vector2 rotation = new Vector3(0.0f, 0.0f);

        private InterfaceElement[] interfaceElements;
        private InterfaceAnimation interfaceAnimation;

        private void Start()
        {
            interfaceAnimation = GetComponent<InterfaceAnimation>();
            interfaceElements = GetComponentsInChildren<InterfaceElement>();

            if(interfaceAnimation.duration == 0)
            {
                Debug.LogWarning("You must specify a duration for your animation to run.");
                return;
            }

            for (int i = 0; i < interfaceElements.Length; i++)
            {
                InterfaceElement interfaceElement = interfaceElements[i];
                InterfaceAnimation animation = interfaceElement.GetComponent<InterfaceAnimation>();
                RectTransform rectTransform = interfaceElement.gameObject.GetComponent<RectTransform>();

                // HEHE THIS IS A NUMBER
                animation.duration = interfaceAnimation.duration;

                // COPY VECTORS
                animation.translation = interfaceAnimation.translation;
                animation.rotation = interfaceAnimation.rotation;
                animation.scale = interfaceAnimation.scale;

                // COPY ANIMATION CURVES
                animation.translationCurve = interfaceAnimation.translationCurve;
                animation.rotationCurve = interfaceAnimation.rotationCurve;
                animation.scaleCurve = interfaceAnimation.scaleCurve;


                switch (layout)
                {
                    case Layout.GRID:
                        animation.translation = new Vector3(
                            animation.translation.x + origin.x + (flipX ? -1 : 1) * (margin.x + rectTransform.rect.width) * (i % cellSize),
                            animation.translation.y + origin.y + (flipY ? -1 : 1) * (margin.y + rectTransform.rect.height) * (i / cellSize),
                            0.0f
                        );
                        break;
                    case Layout.HORIZONTAL:
                        animation.translation = new Vector3(
                            animation.translation.x + origin.x + (flipX ? -1 : 1) * (margin.x + rectTransform.rect.width) * i,
                            animation.translation.y + origin.y,
                            0.0f
                        );
                        break;
                    case Layout.VERTICAL:
                        animation.translation = new Vector3(
                            animation.translation.x + origin.x,
                            animation.translation.y + origin.y + (flipY ? -1 : 1) * (margin.y + rectTransform.rect.height) * i,
                            0.0f
                        );
                        break;
                }
            }

            for (int i = 0; i < interfaceElements.Length; i++)
            {
                InterfaceElement interfaceElement = interfaceElements[i];
                InterfaceAnimation animation = interfaceElement.GetComponent<InterfaceAnimation>();
                if (!animation.independent) StartCoroutine(animation.Animate((i + 1) * animationInterval));
            }
        }

        public void Build()
        {
            interfaceElements = GetComponentsInChildren<InterfaceElement>();

            for (int i = 0; i < interfaceElements.Length; i++)
            {
                InterfaceElement interfaceElement = interfaceElements[i];

                RectTransform rectTransform = interfaceElement.gameObject.GetComponent<RectTransform>();
                rectTransform.sizeDelta = dimension;
                rectTransform.localScale = scale;
                rectTransform.rotation = Quaternion.Euler(rotation);

                switch (layout)
                {
                    case Layout.GRID:
                        rectTransform.localPosition = new Vector3(
                            origin.x + (flipX ? -1 : 1) * (margin.x + rectTransform.rect.width) * (i % cellSize),
                            origin.y + (flipY ? -1 : 1) * (margin.y + rectTransform.rect.height) * (i / cellSize),
                            0.0f
                        );
                        break;
                    case Layout.HORIZONTAL:
                        rectTransform.localPosition = new Vector3(
                            origin.x + (flipX ? -1 : 1) * (margin.x + rectTransform.rect.width) * i,
                            origin.y,
                            0.0f
                        );
                        break;
                    case Layout.VERTICAL:
                        rectTransform.localPosition = new Vector3(
                            origin.x,
                            origin.y + (flipY ? -1 : 1) * (margin.y + rectTransform.rect.height) * i,
                            0.0f
                        );
                        break;
                }
            }
        }
    }
}
