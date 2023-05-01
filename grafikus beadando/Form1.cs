using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafikus_beadando
{
    public partial class Halmazok : Form
    {
        public Halmazok()
        {
            InitializeComponent();
        }

        Random r = new Random();
        int An,Bn;
        List<int> A = new List<int>();
        List<int> B = new List<int>();
        List<int> AuB = new List<int>();
        List<int> AmB = new List<int>();
        List<int> AB = new List<int>();
        List<int> BA = new List<int>();

        private void General_Click(object sender, EventArgs e)
        {
            ErtekBeallitas();
            KezdoHalmazGen(A,An);
            KezdoHalmazGen(B,Bn);
            Unio();
            Metszet();
            ABhalmaz(AB,A);
            ABhalmaz(BA,B);
            Megjelenites();
        }

        private void ABhalmaz(List<int> halmaz,List<int> mainHalmaz)
        {
            for (int i = 0; i < mainHalmaz.Count; i++)
            {
                if (!AmB.Contains(mainHalmaz[i]))
                    halmaz.Add(mainHalmaz[i]);
            }
        }

        private void Metszet()
        {
            AmB = new List<int>(A.Intersect(B));
        }

        private void Unio()
        {
            for (int i = 0; i < A.Count; i++)
            {
                AuB.Add(A[i]);
            }
            for (int i = 0; i < B.Count; i++)
            {
                if (!AuB.Contains(B[i]))
                    AuB.Add(B[i]);
            }
        }

        private void ErtekBeallitas()
        {
            An = Convert.ToInt32(AelemSzam.Value);
            Bn = Convert.ToInt32(BelemSzam.Value);
            A.Clear();
            B.Clear();
            AuB.Clear();
            AmB.Clear();
            AB.Clear();
            BA.Clear();
        }

        private void Megjelenites()
        {
            Megjelenit(A,AlistBox);
            Adb.Text = A.Count + "db";
            Megjelenit(B,BlistBox);
            Bdb.Text = B.Count + "db";
            Megjelenit(AuB,UniolistBox);
            AuBdb.Text = AuB.Count + "db";
            Megjelenit(AmB,MetszetlistBox);
            AmBdb.Text = AmB.Count + "db";
            Megjelenit(AB,ABlistBox);
            ABdb.Text = AB.Count + "db";
            Megjelenit(BA,BAlistBox);
            BAdb.Text = BA.Count + "db";
        }

        private void Megjelenit(List<int> halmaz, ListBox x)
        {
            x.Items.Clear();
            for (int i = 0; i < halmaz.Count; i++)
            {
                x.Items.Add(halmaz[i]);
            }
        }

        private void AelemSzam_ValueChanged(object sender, EventArgs e)
        {
            General.Enabled = AelemSzam.Value>0 && BelemSzam.Value>0;
        }

        private void BelemSzam_ValueChanged(object sender, EventArgs e)
        {
            General.Enabled = AelemSzam.Value > 0 && BelemSzam.Value > 0;
        }

     
        private void KezdoHalmazGen(List<int> halmaz,int n)
        {
            for (int i = 0; i < n; i++)
            {
                int rand = r.Next(0, 100);
                while(halmaz.Contains(rand))
                {
                    rand = r.Next(0, 100);
                }
                halmaz.Add(rand);
            }
        }
    }
}
