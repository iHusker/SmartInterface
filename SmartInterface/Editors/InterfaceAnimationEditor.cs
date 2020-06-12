using SmartInterface.Elements;
using UnityEditor;
using UnityEngine;

namespace SmartInterface.Editors
{
    [CustomEditor(typeof(InterfaceAnimation))]
    [CanEditMultipleObjects]
    class InterfaceAnimationEditor : Editor
    {
        private int index = 0;
        public enum Type { ROTATION = 0, TRANSLATION = 1, SCALE = 2 }

        //Updates InterfaceAnimation values based on inspector value.
        public override void OnInspectorGUI()
        {
            InterfaceAnimation interfaceAnimation = target as InterfaceAnimation;

            EditorGUILayout.Space();
            interfaceAnimation.duration = EditorGUILayout.FloatField("Duration", interfaceAnimation.duration);
            interfaceAnimation.independent = EditorGUILayout.Toggle("Independent", interfaceAnimation.independent);
            EditorGUILayout.Space();

            index = GUILayout.Toolbar(index, new string[] { Type.ROTATION.ToString(), Type.TRANSLATION.ToString(), Type.SCALE.ToString() });

            //When a certain tab is active you can set the values.
            switch (index)
            {
                case (int)Type.ROTATION:
                    interfaceAnimation.rotation = EditorGUILayout.Vector2Field("Vector", interfaceAnimation.rotation);
                    interfaceAnimation.rotationCurve = EditorGUILayout.CurveField("Animation", interfaceAnimation.rotationCurve);
                    break;
                case (int)Type.TRANSLATION:
                    interfaceAnimation.translation = EditorGUILayout.Vector3Field("Vector", interfaceAnimation.translation);
                    interfaceAnimation.translationCurve = EditorGUILayout.CurveField("Animation", interfaceAnimation.translationCurve);
                    break;
                case (int)Type.SCALE:                    
                    interfaceAnimation.scale = EditorGUILayout.Vector2Field("Vector", interfaceAnimation.scale);
                    interfaceAnimation.scaleCurve = EditorGUILayout.CurveField("Animation", interfaceAnimation.scaleCurve);
                    break;
            }
        }
    }
}
