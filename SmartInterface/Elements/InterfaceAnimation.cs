using System;
using System.Collections;
using UnityEngine;

namespace SmartInterface.Elements
{
    public class InterfaceAnimation : MonoBehaviour
    {
        public float duration;
        public bool independent = false;

        public AnimationCurve translationCurve, rotationCurve, scaleCurve;

        public Vector2 translation;
        public Vector2 scale;
        public Vector3 rotation;

        private void Start()
        {
            if (independent)
            {
                if (duration == 0)
                {
                    Debug.LogWarning("You must specify a duration for your animation to run.");
                    return;
                }

                StartCoroutine(Animate(duration));
            }
        }

        public IEnumerator Animate(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            float i = 0.0f;
            float rate = 1.0f / duration;

            while (i < 1.0f)
            {
                i += rate * Time.deltaTime;

                float distance = Vector2.Distance(transform.localPosition, translation);
                transform.localPosition = Vector2.Lerp(transform.localPosition, translation, translationCurve.Evaluate(i));

                float angle = Quaternion.Angle(transform.localRotation, Quaternion.Euler(rotation));
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation), rotationCurve.Evaluate(i));

                transform.localScale = Vector2.Lerp(transform.localScale, this.scale, scaleCurve.Evaluate(i));

                Vector2 localScale = new Vector2(transform.localScale.x, transform.localScale.y);
                float scale = (localScale - this.scale).magnitude;

                if (angle <= 0.2f && distance <= 0.2f && scale <= 0.2f) yield break;

                yield return null;
            }

            Debug.Log("Test2");
        }
    }
}
