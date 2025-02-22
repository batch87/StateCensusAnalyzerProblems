﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static IndianStateCensusAnalyser.StateCensusException;

namespace IndianStateCensusAnalyser
{
    public class CSVState
    {
        public string CSVDataUsingEnumerator(string CSVPath, char delimiter = ',')
        {
            FileInfo fileInfo = new FileInfo(CSVPath);
            if (Path.GetExtension(CSVPath) != ".csv")
                throw new StateCensusException(Exception_Type.Wrong_Type_Exception.ToString());
            if (!File.Exists(CSVPath))
                throw new StateCensusException(Exception_Type.wrong_path_Exception.ToString());
            string[] Lines = File.ReadAllLines(CSVPath);
            if (Lines[0] != "SrNo,State,Name,TIN,StateCode")
                throw new StateCensusException(Exception_Type.Wrong_Header_Exception.ToString());
            int count = 0;
            foreach (var line in File.ReadLines(CSVPath))
            {
                count++;
                string[] LineCount = line.Split(delimiter);
                if (LineCount.Length != 4 && LineCount.Length < 2)
                    throw new StateCensusException(Exception_Type.delimeter_exception.ToString());
                else
                    Console.WriteLine(line);
            }
            
            //IEnumerable<string> iterator = Lines;
            
           // foreach (var item in iterator)
           
                
            return count.ToString();
        }
    }
}
