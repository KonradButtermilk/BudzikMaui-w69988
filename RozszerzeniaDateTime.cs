﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCatAlarm;

/// <summary>
/// Zestaw rozszerzeń pomocniczych dla typu <see cref="DateTime"/>.
/// </summary>
public static class RozszerzeniaDateTime
{
    /// <summary>
    /// Returns a new <see cref="DateTime"/> that represents the next whole minute.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime NextMinute(this DateTime dateTime)
    {
        return dateTime.AddMinutes(1).AddSeconds(-dateTime.Second);
    }
}
