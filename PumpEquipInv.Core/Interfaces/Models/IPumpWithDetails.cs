using PumpEquipInv.Core.Domain;

namespace PumpEquipInv.Core.Interfaces.Models;

public interface IPumpWithDetails: IPump
{
    public Material framematerial { get; set; }
    public Motor motor { get; set; }
    public Material wheelmaterial { get; set; }
}