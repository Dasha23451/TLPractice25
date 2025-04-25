﻿using Fighters.Models.Fighter;

namespace Fighters.Extensions;

public static class IFighterExtensions
{
    public static bool IsAlive( this IFighter fighter ) => fighter.CurrentHealth > 0;
}
