﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader {

	public static List<string> ReadTextFile(string filepath)
    {
        List<string> rows = new List<string>();
        if (File.Exists(filepath))
        {
            using (var reader = new StreamReader(filepath))
            {
                while (true)
                {
                    string row = reader.ReadLine();
                    if (row == null)
                        //if (rows.Count >= 5)
                        break;

                    rows.Add(row.Trim());
                }
                reader.Close();
            }
            return rows;
        }
        return null;
    }

    public static List<string> TextAssetToList(TextAsset ta) {
        return new List<string>(ta.text.Split(System.Environment.NewLine.ToCharArray()));
    }
}
