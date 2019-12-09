using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
public class Textutil : MonoBehaviour
{
    public static bool isuAlpha (char c)
    {
        return c >= 'A' && c<= 'Z';
    }
    public static bool islAlpha(char c)
    {
        return c >= 'a' && c <= 'z';
    }
    public static bool isAlpha(char c)
    {
        return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    }

}
}