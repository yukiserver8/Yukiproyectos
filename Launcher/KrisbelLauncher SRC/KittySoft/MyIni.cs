using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;

namespace KittySoft
{
    public class MyIni
    {
        private string strFilename;

        public string FileName
        {
            get
            {
                return this.strFilename;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WritePrivateProfileString")]
        public static extern int FlushPrivateProfileString(int lpApplicationName, int lpKeyName, int lpString, string lpFileName);

        public MyIni(string Filename)
        {
            this.strFilename = Filename;
        }

        public string GetString(string Section, string Key, string Default)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            int privateProfileString = MyIni.GetPrivateProfileString(Section, Key, Default, stringBuilder, stringBuilder.Capacity, this.strFilename);
            bool flag = privateProfileString > 0;
            string result;
            if (flag)
            {
                result = Strings.Left(stringBuilder.ToString(), privateProfileString);
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }

        public int GetInteger(string Section, string Key, int Default)
        {
            return MyIni.GetPrivateProfileInt(Section, Key, Default, this.strFilename);
        }

        public bool GetBoolean(string Section, string Key, bool Default)
        {
            return (GetPrivateProfileInt(Section, Key, System.Convert.ToInt32(Default), strFilename) == 1);
        }

        public void WriteString(string Section, string Key, string Value)
        {
            MyIni.WritePrivateProfileString(Section, Key, Value, this.strFilename);
            this.Flush();
        }

        public void WriteInteger(string Section, string Key, int Value)
        {
            this.WriteString(Section, Key, Conversions.ToString(Value));
            this.Flush();
        }

        public void WriteBoolean(string Section, string Key, bool Value)
        {
            this.WriteString(Section, Key, System.Convert.ToString(System.Convert.ToInt32(Value)));
            this.Flush();
        }

        private void Flush()
        {
            MyIni.FlushPrivateProfileString(0, 0, 0, this.strFilename);
        }
    }
}
