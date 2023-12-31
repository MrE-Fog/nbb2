﻿// Copyright (c) TotalSoft.
// This source code is licensed under the MIT license.

namespace NBB.ProcessManager.Runtime.Events
{
    public record EventReceived(object ReceivedEvent, string ReceivedEventType);

    public record StateUpdated<TState>(TState State);

    public record ProcessAborted;

    public record ProcessCompleted();

    public record ProcessStarted(object InstanceId);

    public record ProcessTimeout;
}