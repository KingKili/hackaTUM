﻿using Ausgaben_Rechner.Classes;
using HackaTUM.Classes.Daten;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackaTUM.Classes
{
    class CalendarHandler
    {
        //--------------------------------------------------------Atribute:-------------------------------------------------------------------\\
        #region --Atribute--
        private static List<StringDataEntity> calendarEntries = new List<StringDataEntity>();
        private static StringDataEntity nextEntrie = new StringDataEntity("", DateTime.Now);

        #endregion
        //--------------------------------------------------------Construktoren:--------------------------------------------------------------\\
        #region --Construktoren--



        #endregion
        //--------------------------------------------------------Set-, Get- Metoden:---------------------------------------------------------\\
        #region --Set-, Get- Metode--



        #endregion
        //--------------------------------------------------------Sonstige Metoden:-----------------------------------------------------------\\
        #region --Sonstige Metoden (Public)--

        public static List<StringDataEntity> getCalendarList()
        {
            return splitCalendarString(getICalUrl());
        }

        public static String getICalUrl()
        {
            return (Convert.ToString(DataStorage.INSTANCE.userData.iCall));
        }

        //private static List<StringDataEntity> splitCalendarString(string s)
        //{
        //    string[] lines = s.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        //    char delimeter = '!';

        //    for (int line = 0; line < lines.Length; line++)
        //    {
        //        string source = lines[line];
        //        string entry = string.Empty;
        //        string dateString = string.Empty;
                
        //        int count = 0;
        //        for (int i = 0; i < source.Length; i++)
        //        {
        //            if (source[i] != delimeter && count == 1)
        //            {
        //                entry += source[i];
        //            }
        //            else if (source[i] != delimeter && count > 2)
        //            {
        //                dateString += source[i];
        //            }
        //            else count++;               
        //        }
        //        DateTime date = Convert.ToDateTime(dateString);
        //        calendarEntries.Add(new StringDataEntity(entry, DateTime.Now));     //DateTime.Now durch in Date konvertierter date-String ersetzen
        //        Debug.WriteLine(entry);
        //        Debug.WriteLine(date);
        //    }

        //    return calendarEntries;
        //}

        public static StringDataEntity getNextEntry()
        {
            DateTime currentDate = DateTime.Now;
            List<StringDataEntity> workList = calendarEntries;
            List<StringDataEntity> workList2 = new List<StringDataEntity>();
            for (int i = 0; i < workList.Count; i++)
            {
                if (currentDate.CompareTo(workList[i].date) > 0)
                {
                    workList2.Add(workList[i]);
                }                              
            }
            nextEntrie = workList2[0];
            return nextEntrie;
        }


        #endregion

        #region --Sonstige Metoden (Private)--

        private static List<StringDataEntity> splitCalendarString(string s)
        {
            string[] lines = s.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            char delimeter = '!';

            for (int line = 0; line < lines.Length; line++)
            {
                string source = lines[line];
                string entry = string.Empty;
                string dateString = string.Empty;

                int count = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] != delimeter && count == 1)
                    {
                        entry += source[i];
                    }
                    else if (source[i] != delimeter && count > 2)
                    {
                        dateString += source[i];
                    }
                    else count++;
                }
                DateTime date = Convert.ToDateTime(dateString);
                calendarEntries.Add(new StringDataEntity(entry, DateTime.Now));     //DateTime.Now durch in Date konvertierter date-String ersetzen
                //Debug.WriteLine(entry);
                //Debug.WriteLine(date);
            }

            return calendarEntries;
        }

        #endregion

        #region --Sonstige Metoden (Protected)--



        #endregion
        //--------------------------------------------------------Events:---------------------------------------------------------------------\\
        #region --Events--



        #endregion

    }
    }
