using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lorentz
{
    public partial class MainForm : Form
    {
        //HashSet<String> features = new HashSet<String>();
        SortedDictionary<String,SortedDictionary<String,HashSet<String>>> exemplars = new SortedDictionary<String,SortedDictionary<String,HashSet<String>>>();
        float q = 0.01f;
        Random random = new Random();

        public void InitializeNetwork()
        {
            // features
            /*features.Add("fast"); features.Add("slow");
            features.Add("big"); features.Add("small");
            features.Add("light"); features.Add("dark");
            features.Add("long"); features.Add("short");
            features.Add("red");
            features.Add("blue");
            features.Add("green");
            features.Add("grey");
            features.Add("white");
            features.Add("black");
            features.Add("unclear"); features.Add("clear");
            features.Add("round"); features.Add("pointy");
            features.Add("ugly"); features.Add("cute"); features.Add("beautiful");
            features.Add("sharp"); features.Add("dull");
            features.Add("boring");
            features.Add("annoying");
            features.Add("calm"); features.Add("vicious");
            features.Add("crazy"); features.Add("serious");
            features.Add("empty"); features.Add("full");
            features.Add("old"); features.Add("young");
            features.Add("feminine"); features.Add("masculine");
            features.Add("tough"); features.Add("wimpy");
            features.Add("hard"); features.Add("soft");
            features.Add("initial"); features.Add("terminal");
            features.Add("fertile"); features.Add("dead");
            features.Add("wet"); features.Add("dry");
            features.Add("cold"); features.Add("hot");
            features.Add("smart"); features.Add("dumb");*/

            // weather
            HashSet<String> set;
            SortedDictionary<String, HashSet<String>> catex;
            catex = exemplars["weather"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["rain"] = new HashSet<String>(); set.Add("grey"); set.Add("unclear"); set.Add("annoying"); set.Add("wet");
            set = catex["thunder"] = new HashSet<String>(); set.Add("dark"); set.Add("unclear"); set.Add("ugly"); set.Add("annoying"); set.Add("tough");
            set = catex["wind"] = new HashSet<String>(); set.Add("sharp"); set.Add("tough"); set.Add("cold");
            set = catex["storm"] = new HashSet<String>(); set.Add("dark"); set.Add("unclear"); set.Add("cold");
            set = catex["sunshine"] = new HashSet<String>(); set.Add("light"); set.Add("white"); set.Add("clear"); set.Add("beautiful"); set.Add("calm"); set.Add("dry"); set.Add("hot");
            set = catex["snow"] = new HashSet<String>(); set.Add("white"); set.Add("calm"); set.Add("cold");
            set = catex["clouds"] = new HashSet<String>(); set.Add("grey"); set.Add("unclear"); set.Add("soft");

            // animals
            catex = exemplars["animals"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["monkey"] = new HashSet<String>(); set.Add("crazy"); set.Add("dumb");
            set = catex["dog"] = new HashSet<String>(); set.Add("crazy");
            set = catex["rabbit"] = new HashSet<String>(); set.Add("small"); set.Add("cute");
            set = catex["snake"] = new HashSet<String>(); set.Add("long"); set.Add("round"); set.Add("tough");
            set = catex["shark"] = new HashSet<String>(); set.Add("big"); set.Add("vicious");
            set = catex["fox"] = new HashSet<String>(); set.Add("fast"); set.Add("tough"); set.Add("smart");
            set = catex["elephant"] = new HashSet<String>(); set.Add("slow"); set.Add("big"); set.Add("grey"); set.Add("calm"); set.Add("old");

            // flowers
            catex = exemplars["flowers"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["rose"] = new HashSet<String>(); set.Add("red"); set.Add("beautiful"); set.Add("feminine");
            set = catex["lilly"] = new HashSet<String>(); set.Add("beautiful"); set.Add("feminine");

            // emotions
            catex = exemplars["emotions"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["love"] = new HashSet<String>(); set.Add("light"); set.Add("initial"); set.Add("red"); set.Add("beautiful"); set.Add("crazy");
            set = catex["hate"] = new HashSet<String>(); set.Add("dark"); set.Add("terminal"); set.Add("red");
            set = catex["envy"] = new HashSet<String>(); set.Add("dark"); set.Add("green"); set.Add("vicious"); set.Add("cold");
            set = catex["anger"] = new HashSet<String>(); set.Add("dark"); set.Add("red"); set.Add("vicious");
            set = catex["joy"] = new HashSet<String>(); set.Add("light"); set.Add("white"); set.Add("beautiful");
            set = catex["death"] = new HashSet<String>(); set.Add("dark"); set.Add("black"); set.Add("dead"); set.Add("dry"); set.Add("cold");
            set = catex["conflict"] = new HashSet<String>(); set.Add("red"); set.Add("vicious"); set.Add("serious");

            // celestial
            catex = exemplars["celestial"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["earth"] = new HashSet<String>(); set.Add("big"); set.Add("blue"); set.Add("round"); set.Add("fertile");
            set = catex["moon"] = new HashSet<String>(); set.Add("big"); set.Add("light"); set.Add("white"); set.Add("round"); set.Add("calm");
            set = catex["star"] = new HashSet<String>(); set.Add("light");
            set = catex["sun"] = new HashSet<String>(); set.Add("big"); set.Add("light"); set.Add("white"); set.Add("clear"); set.Add("beautiful"); set.Add("calm"); set.Add("hot");
            set = catex["mars"] = new HashSet<String>(); set.Add("big"); set.Add("red"); set.Add("round"); set.Add("masculine"); set.Add("dry"); set.Add("hot");
            set = catex["venus"] = new HashSet<String>(); set.Add("big"); set.Add("round"); set.Add("vicious"); set.Add("feminine"); set.Add("hot");
            set = catex["supernova"] = new HashSet<String>(); set.Add("big"); set.Add("light"); set.Add("white"); set.Add("terminal"); set.Add("hot");

            // objects
            catex = exemplars["objects"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["table"] = new HashSet<String>(); set.Add("boring"); set.Add("hard");
            set = catex["tree"] = new HashSet<String>(); set.Add("big"); set.Add("green"); set.Add("calm"); set.Add("fertile");
            set = catex["chair"] = new HashSet<String>(); set.Add("boring"); set.Add("hard");
            set = catex["bike"] = new HashSet<String>(); set.Add("fast"); set.Add("round");
            set = catex["sword"] = new HashSet<String>(); set.Add("fast"); set.Add("long"); set.Add("sharp"); set.Add("vicious"); set.Add("serious");
            set = catex["pencil"] = new HashSet<String>(); set.Add("long"); set.Add("round"); set.Add("sharp");
            set = catex["spoon"] = new HashSet<String>(); set.Add("round");

            // times
            catex = exemplars["times"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["day"] = new HashSet<String>(); set.Add("light"); set.Add("white");
            set = catex["night"] = new HashSet<String>(); set.Add("dark"); set.Add("black");
            set = catex["summer"] = new HashSet<String>(); set.Add("light"); set.Add("long"); set.Add("beautiful"); set.Add("full"); set.Add("fertile"); set.Add("hot");
            set = catex["winter"] = new HashSet<String>(); set.Add("dark"); set.Add("short"); set.Add("white"); set.Add("dead"); set.Add("empty"); set.Add("cold");
            set = catex["spring"] = new HashSet<String>(); set.Add("beautiful"); set.Add("green"); set.Add("fertile"); set.Add("young");
            set = catex["autumn"] = new HashSet<String>(); set.Add("dead"); set.Add("old");

            // activities
            catex = exemplars["activities"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["running"] = new HashSet<String>(); set.Add("fast"); set.Add("boring"); set.Add("serious");
            set = catex["skiing"] = new HashSet<String>(); set.Add("fast"); set.Add("white"); set.Add("cold");
            set = catex["building"] = new HashSet<String>(); set.Add("hard");
            set = catex["researching"] = new HashSet<String>(); set.Add("smart");
            set = catex["sleeping"] = new HashSet<String>(); set.Add("calm");

            // environment
            catex = exemplars["environment"] = new SortedDictionary<String, HashSet<String>>();
            set = catex["beach"] = new HashSet<String>(); set.Add("white"); set.Add("hot");
            set = catex["sea"] = new HashSet<String>(); set.Add("big"); set.Add("blue"); set.Add("wet");
            set = catex["home"] = new HashSet<String>(); set.Add("calm");
            set = catex["mountain"] = new HashSet<String>(); set.Add("big"); set.Add("old");
            set = catex["road"] = new HashSet<String>(); set.Add("long"); set.Add("clear");
            set = catex["forrest"] = new HashSet<String>(); set.Add("big"); set.Add("green"); set.Add("dark"); set.Add("fertile");
            set = catex["desert"] = new HashSet<String>(); set.Add("big"); set.Add("clear"); set.Add("light"); set.Add("empty"); set.Add("dry"); set.Add("hot");
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeNetwork();
            Generate();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private String GetRandomCategory()
        {
            int n = random.Next() % exemplars.Count;
            int i = 0;
            foreach(String s in exemplars.Keys)
            {
                if(i == n)
                    return s;
                i++;
            }
            return null;
        }

        private String GetRandomExemplar(String cat)
        {
            SortedDictionary<String, HashSet<String>> category = exemplars[cat];
            int n = random.Next() % category.Count;
            int i = 0;
            foreach (String s in category.Keys)
            {
                if (i == n)
                    return s;
                i++;
            }
            return null;
        }

        private void Generate()
        {
            // visualize acceptance ratio
            CompareQRatioTextBox.Text = q.ToString("0.0") + ":1";

            bool done = false;
            String exa = null, exb = null;
            HashSet<String> feata = null, featb = null;
            HashSet<String> inter = null, diff = null;
            while (!done)
            {
                // get two distinct categories
                String cata, catb;
                do
                {
                    cata = GetRandomCategory();
                    catb = GetRandomCategory();
                } while (cata == catb);

                // visualize
                EntityACategoryTextBox.Text = cata;
                EntityBCategoryTextBox.Text = catb;

                // get random exemplar from categories
                exa = GetRandomExemplar(cata);
                exb = GetRandomExemplar(catb);

                // visualize
                EntityAExemplarTextBox.Text = exa;
                EntityBExemplarTextBox.Text = exb;

                // get all features for each exemplar
                feata = exemplars[cata][exa];
                featb = exemplars[catb][exb];

                // visualize
                String names = "";
                foreach (String s in feata)
                    names += s + "\r\n";
                EntityASurroundingTextBox.Text = names;
                names = "";
                foreach (String s in featb)
                    names += s + "\r\n";
                EntityBSurroundingTextBox.Text = names;

                // calculate strict intersection and difference sets
                inter = new HashSet<String>();
                diff = new HashSet<String>();
                foreach (String sa in feata)
                {
                    if (featb.Contains(sa))
                        inter.Add(sa);
                    else
                        diff.Add(sa);
                }
                foreach(String sb in featb)
                    if(!feata.Contains(sb))
                        diff.Add(sb);

                // visualize
                CompareSimilarityTextBox.Text = inter.Count.ToString("0");
                CompareDissimilarityTextBox.Text = diff.Count.ToString("0");

                // calculate verdict
                if ((float)inter.Count / (float)diff.Count > q)
                {
                    done = true;
                    CompareVerdictTextBox.Text = "Accepted";
                    CombinationTextBox.Text = exa + " " + exb;
                }
                else
                {
                    CompareVerdictTextBox.Text = "Rejected";
                    CombinationTextBox.Text = "";
                    //PoeticTextBox.Text = "";
                }
            }

            // be poetic
            String ccexa = Char.ToUpper(exa[0]) + exa.Substring(1, exa.Length - 1);
            String ccexb = Char.ToUpper(exb[0]) + exb.Substring(1, exb.Length - 1);

            if (feata.Count > featb.Count)
                PoeticTextBox.Text = ccexa + ccexb + "\r\n\r\n" + exb + " is like " + exa + "\r\n";
            else
                PoeticTextBox.Text = ccexb + ccexa + "\r\n\r\n" + exa + " is like " + exb + "\r\n";
            bool first = true;
            foreach (String s in inter)
                if (first)
                {
                    PoeticTextBox.Text += s;
                    first = false;
                }
                else
                    PoeticTextBox.Text += ", " + s;
            PoeticTextBox.Text += "\r\n";
        }
    }
}
