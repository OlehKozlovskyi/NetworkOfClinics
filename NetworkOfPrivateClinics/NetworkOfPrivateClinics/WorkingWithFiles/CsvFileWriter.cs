﻿using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class CsvFileWriter : IFileWriter
    {
        public CsvFileWriter(FullPathCreator fullPathCreator)
        {
            FullPath = fullPathCreator.GetFullPath();
        }

        public string FullPath { get; }

        //Implement handmade Clinic Parser to CVS;
        public void Write(ClinicRepository clinicsList)
        {
            string str = "1";
            using (var sw = new StreamWriter(FullPath))
            using (var writer = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                writer.WriteRecords(clinicsList.GetClinics());
            }
        }
    }
}
