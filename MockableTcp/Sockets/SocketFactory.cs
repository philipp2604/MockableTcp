﻿using MockableTcp.Interfaces;
using System.Net.Sockets;

namespace MockableTcp.Sockets;

/// <summary>
/// Implements ISocketFactory.
/// </summary>
public class SocketFactory : ISocketFactory
{
    /// <inheritdoc/>
    public ISocket CreateSocket(AddressFamily? addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        ArgumentNullException.ThrowIfNull(socketType, nameof(socketType));
        ArgumentNullException.ThrowIfNull(protocolType, nameof(protocolType));

        return addressFamily != null ? new SocketWrapper((AddressFamily)addressFamily, socketType, protocolType) : new SocketWrapper(socketType, protocolType);
    }
}