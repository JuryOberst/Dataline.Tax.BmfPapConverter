﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Dataline.Tax.BmfPapConverter.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "BmfTestData")]
    public class NewBmfTestDataCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Lohnsteuer-Prüftabelle")]
        public decimal[][] Table { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Einkommensbezogener Zusatzbeitragssatz")]
        public decimal Kvz { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Krankenversicherung"), ValidateRange(0, 2)]
        public decimal Pkv { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Merker für die Vorsorgepauschale"), ValidateRange(0, 2)]
        public decimal Krv { get; set; }

        [Parameter(Mandatory = true)]
        public FileInfo OutputPath { get; set; }

        protected override void ProcessRecord()
        {
            const string header =
                "lfd. Nr.;STKL;AF;F;ZKF;AJAHR;ALTER1;RE4;VBEZ;LZZ;KRV;KVZ;PKPV;PKV;PVS;PVZ;R;" +
                "LZZFREIB;LZZHINZU;VJAHR;VBEZM;VBEZS;ZMVB;JRE4;JVBEZ;JFREIB;JHINZU;JRE4ENT;" +
                "SONSTB;STERBE;VBS;SONSTENT;VKAPA;VMT;ENTSCH;LSTLZZ";
            var culture = new CultureInfo("de-DE"); // Deutsche Dezimaltrenner in CSV

            int lfdnr = 1;

            using (var stream = OutputPath.OpenWrite())
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(header);

                foreach (var row in Table)
                {
                    if (row.Length != 7)
                        throw new InvalidOperationException("Eine Zeile muss exakt 7 Spalten haben.");

                    decimal jahresbruttolohn = row[0];

                    for (int steuerklasse = 1; steuerklasse != 7; steuerklasse++)
                    {
                        decimal jahreslohnsteuer = row[steuerklasse];

                        decimal lzz = 1m; // Jahr
                        decimal stkl = steuerklasse;
                        decimal pvz = steuerklasse != 2 ? 1 : 0;
                        decimal re4 = jahresbruttolohn * 100;
                        decimal jre4 = jahresbruttolohn * 100;
                        decimal ajahr = 2040; // Geburt 1975
                        decimal alter1 = 0; // 64. LJ endet nach Ende des LZZ

                        // Spalten gemäß des Headers
                        // Nicht gesetzte Felder werden auf ihre Default-Werte gesetzt
                        decimal[] csvRow =
                        {
                            lfdnr++, // lfd. Nr.
                            stkl, // STKL
                            1m, // AF
                            1m, // F
                            0m, // ZKF
                            ajahr, // AJAHR
                            alter1, // ALTER1
                            re4, // RE4
                            0m, // VBEZ
                            lzz, // LZZ
                            Krv, // KRV
                            Kvz, // KVZ
                            0m, // PKPV
                            Pkv, // PKV
                            0m, // PVS
                            pvz, // PVZ
                            0m, // R
                            0m, // LZZFREIB
                            0m, // LZZHINZU
                            0m, // VJAHR
                            0m, // VBEZM
                            0m, // VBEZS
                            0m, // ZMVB
                            jre4, // JRE4
                            0m, // JVBEZ
                            0m, // JFREIB
                            0m, // JHINZU
                            0m, // JRE4ENT
                            0m, // SONSTB
                            0m, // STERBE
                            0m, // VBS
                            0m, // SONSTENT
                            0m, // VKAPA
                            0m, // VMT
                            0m, // ENTSCH
                            jahreslohnsteuer * 100 // LSTLZZ
                        };

                        writer.WriteLine(string.Join(";", csvRow.Select(r => r.ToString(culture))));
                    }
                }
            }
        }
    }
}