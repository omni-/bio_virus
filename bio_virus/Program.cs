﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bio_virus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Random rand = new Random();
        public static int timeBefore, timeAfter;
        public static List<ResistantVirus> viruses = new List<ResistantVirus>();
        public static List<int> numviruses = new List<int>();
        public static Dictionary<string, bool> resist = new Dictionary<string, bool>();
        public static Patient patient;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void problem_4()
        {
            if (!resist.ContainsKey("guttagonol"))
                resist.Add("guttagonol", false);
            if (!resist.ContainsKey("grimpex"))
                resist.Add("grimpex", false);
            for (int i = 0; i < 100; i++)
                viruses.Add(new ResistantVirus(.1f, .05f, resist, .005f));
            patient = new Patient(viruses, 1000, resist);
            for (int i = 0; i < timeBefore; i++)
                numviruses.Add(patient.update());
            patient.addperscription("guttagonol");
            patient = new Patient(viruses, 1000, resist);
            for (int i = 0; i <= timeAfter; i++)
                numviruses.Add(patient.update());
        }
        public static IEnumerable<TKey> RandomKey<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TKey> keys = Enumerable.ToList(dict.Keys);
            int size = dict.Count;
            while (true)
            {
                yield return keys[rand.Next(size)];
            }
        }
    }
}
