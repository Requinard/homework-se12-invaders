using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE12Invaders
{
    public partial class InvadersForm : Form
    {
        public Spel spel;
        public InvadersForm()
        {
            InitializeComponent();
        }

        private void VerversSpelstatus()
        {
            // TODO update de tekst van de labels lblAantalInvaders en 
            // lblAantalSteden met de spelinformatie op te vragen bij 
            // de instantie van de klasse Spel.

            lblAantalInvaders.Text = spel.GeefAantalInvaders().ToString();
            lblAantalSteden.Text = spel.GeefAantalSteden().ToString();
            ControleerGewonnen();
            ControleerVerloren();
        }

        private void ControleerVerloren()
        {
            // Indien het spel verloren is wordt de methode
            // StopSpel() aangeroepen. Geef vervolgens een
            // MessageBox weer met een droevige tekst. :-(
            if (spel.IsVerloren())
            {
                StopSpel();
                MessageBox.Show("gg ez");
            }

        }

        private void ControleerGewonnen()
        {
            // Indien het spel gewonnen is wordt de methode
            // StopSpel() aangeroepen. Geef vervolgens een
            // MessageBox weer met een vrolijke tekst. :-)
            if (spel.IsGewonnen())
            {
                StopSpel();
                MessageBox.Show("gg ez rares");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // TODO De instantie van de klasse Spel dient de 
            // invaders te bewegen. Roep hiertoe de methode
            // BeweegInvaders() aan.
            spel.BeweegInvaders();
   
            pbAfbeelding1.Top = gbVeld.Height- (spel.GeefInvaderPositie(0));
            pbAfbeelding2.Top = gbVeld.Height- (spel.GeefInvaderPositie(1));
            pbAfbeelding3.Top = gbVeld.Height- (spel.GeefInvaderPositie(2));
            pbAfbeelding4.Top = gbVeld.Height- (spel.GeefInvaderPositie(3));
            pbAfbeelding5.Top = gbVeld.Height- (spel.GeefInvaderPositie(4));
            pbAfbeelding6.Top = gbVeld.Height- (spel.GeefInvaderPositie(5));

            // TODO Nadat alle invaders bewogen zijn dient 
            // de spelstatus ververst te worden en dient
            // er gecontroleerd te worden of de speler
            // verloren heeft. Roep hiertoe de juiste
            // methodes aan.
            VerversSpelstatus();
        }

        private void SchietInvader(int index, PictureBox afbeelding)
        {
            // TODO Nadat de speler op een invader geklikt heeft
            // komt het programma in deze methode terecht.
            // Er is dan al bepaald om welke afbeelding en welke
            // index de bijbehorende invader heeft in de array van
            // de instantie van de klasse Spel. Het enige dat nog
            // dient te gebeuren is het verwerken van het beschieten
            // van de invader. Roep hiertoe de methode SchietInvader()
            // van de instantie van de klasse Spel aan. Het resultaat
            // van deze aanroep is een bool. Deze bool geeft aan of
            // de levens van de invader op zijn. Indien dat zo is
            // dient de afbeelding onzichtbaar gemaakt te worden,
            // de spelstatus dient ververst te worden, en er dient
            // gecontroleerd te worden of de speler het spel 
            // gewonnen heeft. Pas de property Visible van de
            // afbeelding aan, en roep de juiste methoden aan.

            spel.SchietInvader(index);
        }

        private void StartSpel()
        {
            gbInstellingen.Enabled = false;

            pbAfbeelding1.Visible = true;
            pbAfbeelding2.Visible = true;
            pbAfbeelding3.Visible = true;
            pbAfbeelding4.Visible = true;
            pbAfbeelding5.Visible = true;
            pbAfbeelding6.Visible = true;

            timer.Enabled = true;
            VerversSpelstatus();
        }

        private void StopSpel()
        {
            timer.Enabled = false;
            gbInstellingen.Enabled = true;
        }

        private void pbAfbeelding1_Click(object sender, EventArgs e)
        {
            SchietInvader(0, pbAfbeelding1);
        }

        private void pbAfbeelding2_Click(object sender, EventArgs e)
        {
            SchietInvader(1, pbAfbeelding2);
        }

        private void pbAfbeelding3_Click(object sender, EventArgs e)
        {
            SchietInvader(2, pbAfbeelding3);
        }

        private void pbAfbeelding4_Click(object sender, EventArgs e)
        {
            SchietInvader(3, pbAfbeelding4);
        }

        private void pbAfbeelding5_Click(object sender, EventArgs e)
        {
            SchietInvader(4, pbAfbeelding5);
        }

        private void pbAfbeelding6_Click(object sender, EventArgs e)
        {
            SchietInvader(5, pbAfbeelding6);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            spel = new Spel((int)gbVeld.Height, (int)nudAantalSteden.Value, (int) nudInvaderLevens.Value, (int) nudInvaderSnelheid.Value );
            StartSpel();
        }
    }
}
