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

        List<K�gy�Elem> k�gy� = new List<K�gy�Elem>();
        Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fejX += iranyX * K�gy�Elem.M�ret;
            fejY += iranyY * K�gy�Elem.M�ret;

            K�gy�Elem ke = new K�gy�Elem();
            k�gy�.Add(ke); //Amikor �j fejet nevezt�nk a k�gy�nak, azt beletessz�k a `k�gy�` list�ba is ..
            Controls.Add(ke); //.. �s az �rlap vez�rl�inek a list�j�ba is

            foreach (object item in Controls)
            {
                if (item is K�gy�Elem)
                {
                    K�gy�Elem k = (K�gy�Elem)item;

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
                ujAlma.Left = r.Next(Width/Alma.M�ret)*Alma.M�ret;
                ujAlma.Top = r.Next(Height/Alma.M�ret)*Alma.M�ret;
                Controls.Add(ujAlma);
            }



            K�gy�Elem ujFej = new();
            Controls.Add(ujFej);
            ujFej.Left = fejX;
            ujFej.Top = fejY;

            if (ujAlma.Location == ujFej.Location)
            {
                Application.Exit();
            }

            if (k�gy�.Count > hossz)
            {
                K�gy�Elem lev�gand� = k�gy�[0];
                k�gy�.RemoveAt(0);
                Controls.Remove(lev�gand�);
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