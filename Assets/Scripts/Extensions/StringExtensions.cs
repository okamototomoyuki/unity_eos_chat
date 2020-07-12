using System.Text.RegularExpressions;

namespace eoschat
{
    /// <summary>
    /// string 拡張
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 空か？
        /// </summary>
        /// <param name="s">文字列</param>
        /// <returns>true:空</returns>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// 空ではないか？
        /// </summary>
        /// <param name="s">文字列</param>
        /// <returns>true:空ではない</returns>
        public static bool NotEmpty(this string s) => string.IsNullOrEmpty(s) == false;


        /// <summary>
        /// int に変換
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="error">変換失敗時の値</param>
        /// <returns>int</returns>
        public static byte ToByte(this string s, byte error = 0) => byte.TryParse(s, out byte result) ? result : error;

        /// <summary>
        /// int に変換
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="error">変換失敗時の値</param>
        /// <returns>int</returns>
        public static int ToInt(this string s, int error = -1) => int.TryParse(s, out int result) ? result : error;

        /// <summary>
        /// long に変換
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="error">変換失敗時の値</param>
        /// <returns>long</returns>
        public static long ToLong(this string s, long error = -1) => long.TryParse(s, out long result) ? result : error;

        /// <summary>
        /// 正規表現で置換
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="regex">正規表現</param>
        /// <param name="replace">置換文字列</param>
        /// <returns>置換後の文字列</returns>
        public static string ReplaceAll(this string s, string regex, string replace) => Regex.Replace(s, regex, replace);

        /// <summary>
        /// 正規表現にマッチしたか
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="regex">正規表現</param>
        /// <returns>true:マッチ</returns>
        public static bool IsMatch(this string s, string regex) => Regex.IsMatch(s, regex);

        /// <summary>
        /// Null なら空文字
        /// </summary>
        /// <param name="s">文字列</param>
        /// <returns>文字列または空文字</returns>
        public static string NullToEmp(this string s) => s == null ? string.Empty : s;
    }
}
