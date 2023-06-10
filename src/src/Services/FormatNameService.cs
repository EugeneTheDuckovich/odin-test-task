using System;
using System.Linq;
using src.Services.Abstract;

namespace src.Services;

public class FormatNameService : IFormatNameService
{
    private readonly string[] prefixes;

    public FormatNameService()
    {
        prefixes = new string[]
        {
            "von",
            "vom",
            "de",
            "der",
            "dem",
            "zu",
            "und",
        };
    }
    
    public string FormatFullName(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        nameParts = nameParts.Select(s => FormatNamePart(s)).ToArray();

        return string.Join(' ',nameParts);
    }

    private string FormatNamePart(string namePart)
    {
        var formattedName = namePart.ToLower();
        if (!string.IsNullOrEmpty(formattedName) && !prefixes.Contains(formattedName))
        {
            formattedName = char.ToUpper(formattedName[0]) + formattedName.Substring(1);
        }

        return formattedName;
    }
}