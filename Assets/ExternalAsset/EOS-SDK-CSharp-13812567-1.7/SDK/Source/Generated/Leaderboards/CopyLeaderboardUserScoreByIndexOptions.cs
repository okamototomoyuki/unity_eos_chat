// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	/// <summary>
	/// Input parameters for the <see cref="LeaderboardsInterface.CopyLeaderboardUserScoreByIndex" /> Function.
	/// </summary>
	public class CopyLeaderboardUserScoreByIndexOptions
	{
		/// <summary>
		/// API Version of the <see cref="CopyLeaderboardUserScoreByIndexOptions" /> function.
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Index of the sorted leaderboard user score to retrieve from the cache.
		/// </summary>
		public uint LeaderboardUserScoreIndex { get; set; }

		/// <summary>
		/// Name of the stat used to rank the leaderboard.
		/// </summary>
		public string StatName { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CopyLeaderboardUserScoreByIndexOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private uint m_LeaderboardUserScoreIndex;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_StatName;

		public int ApiVersion
		{
			get
			{
				var value = Helper.GetDefault<int>();
				Helper.TryMarshalGet(m_ApiVersion, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_ApiVersion, value); }
		}

		public uint LeaderboardUserScoreIndex
		{
			get
			{
				var value = Helper.GetDefault<uint>();
				Helper.TryMarshalGet(m_LeaderboardUserScoreIndex, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LeaderboardUserScoreIndex, value); }
		}

		public string StatName
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_StatName, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_StatName, value); }
		}

		public void Dispose()
		{
		}
	}
}