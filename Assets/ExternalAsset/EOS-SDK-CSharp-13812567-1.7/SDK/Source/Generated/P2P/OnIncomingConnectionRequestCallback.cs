// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// Callback for information related to incoming connection requests.
	/// </summary>
	public delegate void OnIncomingConnectionRequestCallback(OnIncomingConnectionRequestInfo data);

	internal delegate void OnIncomingConnectionRequestCallbackInternal(IntPtr messagePtr);
}