// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	/// <summary>
	/// Data for identifying which data records should be deleted.
	/// </summary>
	public class PresenceModificationDataRecordId
	{
		/// <summary>
		/// API Version for the <see cref="PresenceModificationDataRecordId" /> struct
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// The key to be deleted from the data record
		/// </summary>
		public string Key { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct PresenceModificationDataRecordIdInternal : IDisposable
	{
		private int m_ApiVersion;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_Key;

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

		public string Key
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_Key, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_Key, value); }
		}

		public void Dispose()
		{
		}
	}
}