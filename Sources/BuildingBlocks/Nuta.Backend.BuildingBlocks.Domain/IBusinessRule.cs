﻿namespace Nuta.Backend.BuildingBlocks.Domain;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}