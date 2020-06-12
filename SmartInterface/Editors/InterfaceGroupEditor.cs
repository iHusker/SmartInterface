using UnityEditor;
using SmartInterface.Elements;

namespace SmartInterface
{
    [CustomEditor(typeof(InterfaceGroup))]
    [CanEditMultipleObjects]
    class InterfaceGroupEditor : Editor
    {
        //Updates values for the Interfacegroup based on the inspector values
        public override void OnInspectorGUI()
        {
            InterfaceGroup interfaceGroup = (InterfaceGroup)target;

            interfaceGroup.animationInterval = EditorGUILayout.FloatField("Animation Interval", interfaceGroup.animationInterval);
            interfaceGroup.layout = (InterfaceGroup.Layout)EditorGUILayout.EnumPopup("Layout", interfaceGroup.layout);
            interfaceGroup.origin = EditorGUILayout.Vector3Field("Origin", interfaceGroup.origin);

            EditorGUILayout.Space();

            interfaceGroup.cellSize = EditorGUILayout.IntField("Elements Per Row", interfaceGroup.cellSize);
            interfaceGroup.flipX = EditorGUILayout.Toggle("Flip X", interfaceGroup.flipX);
            interfaceGroup.flipY = EditorGUILayout.Toggle("Flip Y", interfaceGroup.flipY);

            EditorGUILayout.Space();

            interfaceGroup.dimension = EditorGUILayout.Vector2Field("Dimension", interfaceGroup.dimension);
            interfaceGroup.margin = EditorGUILayout.Vector2Field("Margin", interfaceGroup.margin);
            interfaceGroup.scale = EditorGUILayout.Vector2Field("Scale", interfaceGroup.scale);
            interfaceGroup.rotation = EditorGUILayout.Vector2Field("Rotation", interfaceGroup.rotation);

            interfaceGroup.Build();
        }
    }
}
