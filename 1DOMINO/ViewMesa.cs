using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _1DOMINO
{
    public partial class ViewMesa : Form
    {
        ViewDecidirJogadores dlg = new ViewDecidirJogadores();

        List<PictureBox> Imagens = new List<PictureBox>(); //Lista com todas as imagens das peças do 1º jogador
        List<PictureBox> Imagens2 = new List<PictureBox>();//Lista com todas as imagens das peças do 2º jogador
        List<PictureBox> Imagens3 = new List<PictureBox>();//Lista com todas as imagens das peças do 3º jogador
        List<PictureBox> Imagens4 = new List<PictureBox>();//Lista com todas as imagens das peças do 4º jogador
        List<PictureBox> ImgPecas = new List<PictureBox>();

        public ViewMesa()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewMesa_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void buttonJogar_Click(object sender, EventArgs e)
        {
            //Jogador 1
            for (int i = 0; i < 7; i++) //para desenhar as 7 peças
            {
                PictureBox p = new PictureBox();
                Image img1 = Image.FromFile(@"C:\\Users\Asus\Desktop\1DOMINO\null.jpg");
                p.Image = img1;
                Imagens.Add(p);

            }

            //Jogador 2
            for (int i = 0; i < 7; i++) //para desenhar as 7 peças
            {
                PictureBox p2 = new PictureBox();
                Image img2 = Image.FromFile(@"C:\\Users\Asus\Desktop\1DOMINO\null.jpg");
                p2.Image = img2;
                Imagens2.Add(p2);
            }

            //Jogador 3

            for (int i = 0; i < 7; i++) //para desenhar as 7 peças
            {
                PictureBox p3 = new PictureBox();
                Image img3 = Image.FromFile(@"C:\\Users\Asus\Desktop\1DOMINO\nullH.jpg");
                p3.Image = img3;
                Imagens3.Add(p3);
            }

            pecasIniciaisJog1();
            pecasIniciaisJog2();
            pecasIniciaisJog3();

            //Mesa
            PictureBox m = new PictureBox();
            Image img = Image.FromFile(@"C:\\Users\Asus\Desktop\1DOMINO\12.jpg");
            m.Image = img;
            ImgPecas.Add(m);
            AdicionaMesa();
        }

            //Desenhar peças iniciais de acordo com o nº jogadores selecionado na View Decidir Jogadores
            //switch (dlg.NumJog)
            //{
            //    case "2":
            //     pecasIniciais();
            //        break;

            //()


        void pecasIniciaisJog1()
        {
            //PANEL 1
            float percentagem = panel1.Controls.Count > 10 ? 0.6f : 1;
            percentagem = panel1.Controls.Count > 7 ? 0.7f : 0.6f;
            
                for (int i = 0; i < Imagens.Count; i++)
                {
                    Imagens[i].Size = new Size()
                    {
                        Width = (int)(100 * percentagem),
                        Height = (int)(100 * percentagem)
                    };
                    Imagens[i].SizeMode = PictureBoxSizeMode.Zoom;
                    Imagens[i].Left = Imagens[i].Width * i;
                    panel1.Controls.Add(Imagens[i]);
                    panel1.Invalidate();

                }
        
        }

        void pecasIniciaisJog2()
        {
            //PANEL 2
            float percentagem = panel2.Controls.Count > 10 ? 0.6f : 1;
            percentagem = panel2.Controls.Count > 7 ? 0.7f : 0.6f;

            for (int i = 0; i < Imagens.Count; i++)
            {
                Imagens2[i].Size = new Size()
                {
                    Width = (int)(100 * percentagem),
                    Height = (int)(100 * percentagem)
                };
                Imagens2[i].SizeMode = PictureBoxSizeMode.Zoom;
                Imagens2[i].Left = Imagens2[i].Width * i;
                panel2.Controls.Add(Imagens2[i]);

            }
        }

        void pecasIniciaisJog3()
        {
            //PANEL 3
            float percentagem = panel3.Controls.Count > 10 ? -0.05f : 1;
            percentagem = panel3.Controls.Count > 7 ? 0.7f : -0.05f;

            for (int i = 0; i < Imagens.Count; i++)
            {
                Imagens3[i].Size = new Size()
                {
                    Width = (int)(100 * percentagem),
                    Height = (int)(100 * percentagem)
                };
                Imagens3[i].SizeMode = PictureBoxSizeMode.Zoom;
                Imagens3[i].Left = Imagens3[i].Width * i;
                panel3.Controls.Add(Imagens3[i]);
                panel3.Invalidate();

            }
        }


            void AdicionaMesa()
        {
            //PANEL MESSA
            float percentagem = panelMesa.Controls.Count > 10 ? 0.6f : 1;
            percentagem = panelMesa.Controls.Count > 7 ? 0.7f : 0.6f;

            for (int i = 0; i < ImgPecas.Count; i++)
            {
                ImgPecas[i].Size = new Size()
                {
                    Width = (int)(100 * percentagem),
                    Height = (int)(100 * percentagem)
                };
                ImgPecas[i].SizeMode = PictureBoxSizeMode.Zoom;
                ImgPecas[i].Left = Imagens2[i].Width * i;
                panelMesa.Controls.Add(ImgPecas[i]);

            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pB1_Click(object sender, EventArgs e)
        {

        }
    }
 }
