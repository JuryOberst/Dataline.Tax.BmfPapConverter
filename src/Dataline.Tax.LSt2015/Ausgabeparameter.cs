/*
 * Automatisch generiert mit Dataline.Tax.BmfPapConverter
 * am 04.04.2017 15:19:39
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Dataline.Tax.LSt2015
{
    public class Ausgabeparameter
    {
        /// <summary>
        /// Bemessungsgrundlage fuer die Kirchenlohnsteuer in Cents
        /// </summary>
        public decimal BK { get; set; } = 0m;

        /// <summary>
        /// Bemessungsgrundlage der sonstigen Einkuenfte (ohne Verguetung
        /// fuer mehrjaehrige Taetigkeit) fuer die Kirchenlohnsteuer in Cents
        /// </summary>
        public decimal BKS { get; set; } = 0m;

        public decimal BKV { get; set; } = 0m;

        /// <summary>
        /// Fuer den Lohnzahlungszeitraum einzubehaltende Lohnsteuer in Cents
        /// </summary>
        public decimal LSTLZZ { get; set; } = 0m;

        /// <summary>
        /// Fuer den Lohnzahlungszeitraum einzubehaltender Solidaritaetszuschlag
        /// in Cents
        /// </summary>
        public decimal SOLZLZZ { get; set; } = 0m;

        /// <summary>
        /// Solidaritaetszuschlag fuer sonstige Bezuege (ohne Verguetung fuer mehrjaehrige
        /// Taetigkeit) in Cents
        /// </summary>
        public decimal SOLZS { get; set; } = 0m;

        /// <summary>
        /// Solidaritaetszuschlag fuer die Verguetung fuer mehrjaehrige Taetigkeit in
        /// Cents
        /// </summary>
        public decimal SOLZV { get; set; } = 0m;

        /// <summary>
        /// Lohnsteuer fuer sonstige Einkuenfte (ohne Verguetung fuer mehrjaehrige
        /// Taetigkeit) in Cents
        /// </summary>
        public decimal STS { get; set; } = 0m;

        /// <summary>
        /// Lohnsteuer fuer Verguetung fuer mehrjaehrige Taetigkeit in Cents
        /// </summary>
        public decimal STV { get; set; } = 0m;

        /// <summary>
        /// Für den Lohnzahlungszeitraum berücksichtigte Beiträge des Arbeitnehmers zur
        /// privaten Basis-Krankenversicherung und privaten Pflege-Pflichtversicherung (ggf. auch
        /// die Mindestvorsorgepauschale) in Cent beim laufenden Arbeitslohn. Für Zwecke der Lohn-
        /// steuerbescheinigung sind die einzelnen Ausgabewerte außerhalb des eigentlichen Lohn-
        /// steuerbescheinigungsprogramms zu addieren; hinzuzurechnen sind auch die Ausgabewerte
        /// VKVSONST
        /// </summary>
        public decimal VKVLZZ { get; set; } = 0m;

        /// <summary>
        /// Für den Lohnzahlungszeitraum berücksichtigte Beiträge des Arbeitnehmers
        /// zur privaten Basis-Krankenversicherung und privaten Pflege-Pflichtversicherung (ggf.
        /// auch die Mindestvorsorgepauschale) in Cent bei sonstigen Bezügen. Der Ausgabewert kann
        /// auch negativ sein. Für tarifermäßigt zu besteuernde Vergütungen für mehrjährige
        /// Tätigkeiten enthält der PAP keinen entsprechenden Ausgabewert.
        /// </summary>
        public decimal VKVSONST { get; set; } = 0m;
    }
}