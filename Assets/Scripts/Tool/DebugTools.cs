using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace eoschat
{
    /// <summary>
    /// デバッグ用ツール 拡張
    /// </summary>
    public static class DebugTools
    {
        /// <summary>
        /// クラスとメソッド名を文字列で取得
        /// </summary>
        /// <returns>クラス・メソッド名</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetClassMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return $"{sf.GetMethod().DeclaringType}.{sf.GetMethod().Name}";
        }
    }
}
