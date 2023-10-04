using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;

/*
 * 약식 기획.
 * 설정에서 변경 가능해야함.
 * 종류는 기본, 한국식 3개, 영어식 2개
 * 
 * 
 */

public static class Shortform
{
    public static String Format(String format, String origin)
    {
        if(String.IsNullOrEmpty(origin).Equals(false) || Regex.IsMatch(origin, @"^[0-9]*$"))
            throw new FormatException(String.Format("The {0} origin string is not made up of numbers.", origin));

        if (String.IsNullOrEmpty(format)) 
            format = "G";

        if (String.IsNullOrEmpty(origin) || origin.Equals("0"))
            return "0";

        switch(format.ToUpperInvariant())
        {
            case "G":
                return FormatGeneral(origin);
            case "KR-0":
                return FormatKR(0, origin);
            case "KR-1":
                return FormatKR(1, origin);
            case "KR-2":
                return FormatKR(2, origin);
            case "EN-0":
                return FormatEN(0, origin);
            case "EN-1":
                return FormatEN(1, origin);
            default:
                throw new FormatException(String.Format("The {0} format string is not supported.", format));
        }
    }

    private static string FormatGeneral(String origin)
    {
        StringBuilder sb = new StringBuilder();
        return sb.ToString();
    }

    private static string FormatKR(int type, String origin)
    {
        StringBuilder sb = new StringBuilder();
        return sb.ToString();
    }

    private static string FormatEN(int type, String origin)
    {
        StringBuilder sb = new StringBuilder();
        return sb.ToString();
    }
}
