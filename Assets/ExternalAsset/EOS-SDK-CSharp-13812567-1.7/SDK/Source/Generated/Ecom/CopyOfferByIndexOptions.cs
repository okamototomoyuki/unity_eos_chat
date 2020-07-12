// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	/// <summary>
	/// Input parameters for the <see cref="EcomInterface.CopyOfferByIndex" /> Function.
	/// </summary>
	public class CopyOfferByIndexOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Local user whose offer is being copied
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// The index of the offer to get.
		/// </summary>
		public uint OfferIndex { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CopyOfferByIndexOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private IntPtr m_LocalUserId;
		private uint m_OfferIndex;

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

		public EpicAccountId LocalUserId
		{
			get
			{
				var value = Helper.GetDefault<EpicAccountId>();
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LocalUserId, value); }
		}

		public uint OfferIndex
		{
			get
			{
				var value = Helper.GetDefault<uint>();
				Helper.TryMarshalGet(m_OfferIndex, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_OfferIndex, value); }
		}

		public void Dispose()
		{
		}
	}
}