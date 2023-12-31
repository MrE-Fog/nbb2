﻿// Copyright (c) TotalSoft.
// This source code is licensed under the MIT license.

using System;
using MediatR;

namespace NBB.Contracts.PublishedLanguage
{
    public record AddContractLine(string Product, decimal Price, int Quantity, Guid ContractId) : IRequest;

    public record CreateContract(Guid ClientId) : IRequest;

    public record ValidateContract(Guid ContractId) : IRequest;
}