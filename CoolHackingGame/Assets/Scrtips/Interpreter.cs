using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using Unity.VisualScripting;
using static UnityEngine.Rendering.DebugUI;

public class Interpreter : MonoBehaviour
{
    public EventManager em;
    public GameObject browser;

    List<string> response = new List<string>();
    public List<string> Interpret(string userInput)
    {
        response.Clear();

        string[] args = userInput.Split();

        if (args[0] == "help")
        {
            response.Add("If you want to use the password decypher, type \"ds\" ");
            response.Add("If you want to start your default browser, type \"browser\"");

            return response;
        }
        if (args[0] == "ds")
        {
            Dictionary<string, string> hash_pass = new Dictionary<string, string>()
            {
                {"042", "1021"},
                {"044", "1111"},
                {"130", "A123"},
                {"222", "A1A2"},
                {"310", "8AdH"},
                {"313", "AAA9"}
            };

            if (args.Length < 2)
            {
                response.Add("Usage:");
                response.Add("ds bc <hash> <pass>   shows amount of symbols in place");
                response.Add("ds op <hash> <pass>   shows percentage of how close your password is to actual");

                return response;
            }

            if (args[1] == "bc")
            {
                if (args.Length < 4)
                {
                    response.Add("Hash AND password expected");

                    return response;
                }

                if (hash_pass.ContainsKey(args[2]))
                {
                    if (hash_pass[args[2]].Length != args[3].Length)
                    {
                        response.Add("Length of password does not match the length of the guess");
                        return response;
                    }
                    int bulls = 0;
                    int cows = 0;
                    int[] secretFreq = new int[62];
                    int[] guessFreq = new int[62];

                    for (int i = 0; i < args[3].Length; i++)
                    {
                        if (hash_pass[args[2]][i] == args[3][i]) {bulls++;}
                        else
                        {
                            secretFreq[GetCharIndex(hash_pass[args[2]][i])]++;
                            guessFreq[GetCharIndex(args[3][i])]++;
                        }
                    }

                    for (int i = 0; i < 62; i++) {cows += Math.Min(secretFreq[i], guessFreq[i]);}


                    response.Add($"{bulls} symbols are in correct place");
                    response.Add($"{cows} symbols are not in correct place");
                    return response;
                }
                else
                {
                    response.Add("Couldn't generate password using this hash.");
                    return response;
                }

            }

            if (args[1] == "op")
            {
                if (args.Length < 4)
                {
                    response.Add("Hash AND password expected");

                    return response;
                }

                if (hash_pass.ContainsKey(args[2]))
                {
                    if (hash_pass[args[2]].Length != args[3].Length)
                    {
                        response.Add("Length of password does not match the length of the guess");
                        return response;
                    }

                    double percentage = 0;
                    for (int i = 0; i < hash_pass[args[2]].Length; i++)
                    {
                        percentage += (62d - Math.Abs(GetCharIndex(hash_pass[args[2]][i]) - GetCharIndex(args[3][i]))) * 100d / 62d / hash_pass[args[2]].Length;
                    }
                    //percentage = 100f - percentage;
                    response.Add($"Your password is " + String.Format("{0:#,0.00}", percentage) + "% close to the original");
                    return response;
                }
                else
                {
                    response.Add("Couldn't generate password using this hash.");
                    return response;
                }
            }

            else
            {
                response.Add("Invalid arguments. Type ds for a list of arguments");

                return response;
            }

        }
        if (args[0] == "browser")
        {
            response.Add("Starting \"waffle surfer\"...");
            em.ChangeMode("Browser");
            browser.SetActive(true);
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of commands.");

            return response;
        }
    }
    static int GetCharIndex(char c)
    {
        if (c >= '0' && c <= '9')
            return c - '0'; 

        if (c >= 'a' && c <= 'z')
            return 2*(c - 'a') + 10;

        if (c >= 'A' && c <= 'Z')
            return 2*(c - 'A') + 11;

        throw new ArgumentException("Wrong Symbol");
    }
}
