﻿using System.Text.RegularExpressions;
using Content.Server.Speech.Components;

namespace Content.Server.Speech.EntitySystems;

public sealed class LizardAccentSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<LizardAccentComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, LizardAccentComponent component, AccentGetEvent args)
    {
        var message = args.Message;

        //Ganimed speech-loc start
        // С/с => Ссс/ссс
        message = Regex.Replace(message, "с+", "ссс");
        message = Regex.Replace(message, "С+", "Ссс");
        // Ш/ш => Шшш/шшш
        message = Regex.Replace(message, "ш+", "шшш");
        message = Regex.Replace(message, "Ш+", "Шшш");
        // Щ/щ => Щщщ/щщщ
        message = Regex.Replace(message, "щ+", "щщщ");
        message = Regex.Replace(message, "Щ+", "Щщщ");
        // З/з => Ссс/ссс
        message = Regex.Replace(message, "з+", "Ссс");
        message = Regex.Replace(message, "З+", "Ссс");
        // Ч/ч => Щщщ/щщщ
        message = Regex.Replace(message, "ч+", "щщщ");
        message = Regex.Replace(message, "Ч+", "Щщщ");
        //Ganimed speech-loc end

        // hissss
        message = Regex.Replace(message, "s+", "sss");
        // hiSSS
        message = Regex.Replace(message, "S+", "SSS");
        // ekssit
        //message = Regex.Replace(message, @"(\w)x", "$1kss");
        // ecks
        //message = Regex.Replace(message, @"\bx([\-|r|R]|\b)", "ecks$1");
        // eckS
        //message = Regex.Replace(message, @"\bX([\-|r|R]|\b)", "ECKS$1");

        args.Message = message;
    }
}
