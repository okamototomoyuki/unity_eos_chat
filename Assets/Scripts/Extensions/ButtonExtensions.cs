using UnityEngine.UI;
using UnityEngine.Events;

namespace eoschat
{
    /// <summary>
    /// TMP_InputField 拡張
    /// </summary>
    public static class ButtonExtensions
    {
        /// <summary>
        /// 押下アクション追加
        /// </summary>
        /// <param name="button">ボタン</param>
        /// <param name="act">アクション</param>
        public static void SetOnClick(this Button button, UnityAction act)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(act);
        }
    }
}