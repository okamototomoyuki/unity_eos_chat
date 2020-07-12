// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbySearch.CopySearchResultByIndex" /> Function.
	/// </summary>
	public class LobbySearchCopySearchResultByIndexOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// The index of the lobby to retrieve within the completed search query
		/// <seealso cref="LobbySearch.GetSearchResultCount" />
		/// </summary>
		public uint LobbyIndex { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbySearchCopySearchResultByIndexOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private uint m_LobbyIndex;

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

		public uint LobbyIndex
		{
			get
			{
				var value = Helper.GetDefault<uint>();
				Helper.TryMarshalGet(m_LobbyIndex, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LobbyIndex, value); }
		}

		public void Dispose()
		{
		}
	}
}