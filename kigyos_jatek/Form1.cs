namespace kigyos_jatek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int fejX = 100;
        int fejY = 100;
        int iranyX = 1;
        int iranyY = 0;
        int hossz = 5;
        int lepesszam = 0;

        List<KígyóElem> kígyó = new List<KígyóElem>();
        Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fejX += iranyX * KígyóElem.Méret;
            fejY += iranyY * KígyóElem.Méret;

            KígyóElem ke = new KígyóElem();
            kígyó.Add(ke); //Amikor új fejet neveztünk a kígyónak, azt beletesszük a `kígyó` listába is ..
            Controls.Add(ke); //.. és az ûrlap vezérlõinek a listájába is

            foreach (object item in Controls)
            {
                if (item is KígyóElem)
                {
                    KígyóElem k = (KígyóElem)item;

                    if (k.Top == fejY && k.Left == fejX)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            Alma ujAlma = new Alma();

            if (lepesszam % 15 == 0)
            {
                ujAlma.Left = r.Next(Width/Alma.Méret)*Alma.Méret;
                ujAlma.Top = r.Next(Height/Alma.Méret)*Alma.Méret;
                Controls.Add(ujAlma);
            }



            KígyóElem ujFej = new();
            Controls.Add(ujFej);
            ujFej.Left = fejX;
            ujFej.Top = fejY;

            if (ujAlma.Location == ujFej.Location)
            {
                Application.Exit();
            }

            if (kígyó.Count > hossz)
            {
                KígyóElem levágandó = kígyó[0];
                kígyó.RemoveAt(0);
                Controls.Remove(levágandó);
            }
            if (lepesszam % 5 == 0) hossz++;
            if (lepesszam % 2 == 0) ujFej.BackColor = Color.Purple;
            lepesszam++;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { iranyX = 0; iranyY = -1; }
            if (e.KeyCode == Keys.Down) { iranyX = 0; iranyY = 1; }
            if (e.KeyCode == Keys.Left) { iranyX = -1; iranyY = 0; }
            if (e.KeyCode == Keys.Right) { iranyX = 1; iranyY = 0; }
        }
    }
}