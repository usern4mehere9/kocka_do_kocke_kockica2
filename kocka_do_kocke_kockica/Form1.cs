using System.Drawing;

namespace kocka_do_kocke_kockica
{
    public partial class Form1 : Form
    {
        int x_prvi_klik, y_prvi_klik;
        int x_drugi_klik, y_drugi_klik;
        int x_pravugaonika, y_pravugaonika;
        int stranica_a = 100, stranica_b = 100;
        Graphics g; //MSDN dokumetacija kaze da ovo ide tu

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Nepotrebno u ovoj verziji programa
            //Uzimamo kordinate prvog klika
            //x_prvi_klik = e.X;
            //y_prvi_klik = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            //Uzimamo kordinate drugog klika
            x_drugi_klik = e.X;
            y_drugi_klik = e.Y;

            //trazimo pocetni cosak
            //x_pravugaonika = Math.Min(x_prvi_klik, x_drugi_klik);
            //y_pravugaonika = Math.Min(y_prvi_klik, y_drugi_klik);

            x_pravugaonika = Math.Abs(x_drugi_klik - (stranica_a / 2));
            y_pravugaonika = Math.Abs(y_drugi_klik - (stranica_b / 2));

            //Odredjujemo duzine stranica
            //stranica_a = Math.Abs(x_drugi_klik - x_prvi_klik);
            //stranica_b = Math.Abs(y_drugi_klik - y_prvi_klik);

            //Crtamo pravuogaonik
            g.DrawRectangle(Pens.Magenta, x_pravugaonika, y_pravugaonika, stranica_a, stranica_b);

            //crtamo glavnu dijagonalu
            g.DrawLine(Pens.Cyan, x_pravugaonika, y_pravugaonika, x_pravugaonika + stranica_a, y_pravugaonika + stranica_b);

            //crtamo sporednu dijagonalu
            g.DrawLine(Pens.Yellow, x_pravugaonika + stranica_a, y_pravugaonika, x_pravugaonika, y_pravugaonika + stranica_b);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();  //MSDN dokumentacija kaze da je ovo pozeljno da bude ovde
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Dispose(); //MSDN preporucuje da se ovo stavi ovde (nije neophodno zato sto postoji garbage collector ali je pozeljno)
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.Text = "Prvi klik X: " + x_prvi_klik.ToString();
            //label2.Text = "Prvi klik Y: " + y_prvi_klik.ToString();

            label3.Text = "Klik X: " + x_drugi_klik.ToString();
            label4.Text = "Klik Y: " + y_drugi_klik.ToString();

            label5.Text = "Trenutni X: " + e.X.ToString();
            label6.Text = "Trenutni Y: " + e.Y.ToString();

            //label7.Text = "Stranica A: " + stranica_a.ToString();
            //label8.Text = "Stranica B: " + stranica_b.ToString();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
        }
    }
}
