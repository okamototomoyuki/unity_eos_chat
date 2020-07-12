using System.Text.RegularExpressions;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine;

namespace eoschat
{
    /// <summary>
    /// MonoBehaviour 拡張
    /// </summary>
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// RectTransform 取得
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <returns>RectTransform</returns>
        public static RectTransform GetRectTransform(this MonoBehaviour mono) => mono.transform as RectTransform;

        /// <summary>
        /// GameObject 活性非活性設定
        /// </summary>
        /// <param name="mono">MonoBehaviour</param>
        /// <param name="b">true:活性</param>
        /// <returns>RectTransform</returns>
        public static void SetActive(this MonoBehaviour mono, bool b) => mono.gameObject.SetActive(b);
    }
}