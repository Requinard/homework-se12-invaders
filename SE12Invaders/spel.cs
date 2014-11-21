using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE12Invaders
{
    public class Spel
    {
        private int hoogte;
        private int aantalSteden;
        private int invaderSnelheid;
        private int invaderLevens;
        private Random dobbelsteen;
        private Invader[] invaders;

        public Spel(int hoogte, int aantalSteden, int invaderLevens, int invaderSnelheid)
        {
            this.dobbelsteen = new Random();

            this.hoogte = hoogte;
            this.aantalSteden = aantalSteden;
            this.invaderLevens = invaderLevens;
            this.invaderSnelheid = invaderSnelheid;

            this.invaders = new Invader[6];

            for (int i = 0; i != 6; i++)
            {
                invaders[i] = new Invader(dobbelsteen.Next(invaderLevens, 12), hoogte);
            }
        }

        public int GeefAantalSteden()
        {
            return this.aantalSteden;
        }

        public int GeefAantalInvaders()
        {
            int count = 0;

            foreach (var invader in invaders)
            {
                if (invader.LeeftNog())
                    count++;
            }

            return count;
        }

        public bool IsGewonnen()
        {
            if (GeefAantalInvaders() != 0)
                return false;
            else
                return true;
        }

        public bool IsVerloren()
        {
            if (aantalSteden > 0)
                return false;
            else
                return true;
        }

        public int GeefInvaderPositie(int index)
        {
            return invaders[index].y;
        }

        public bool SchietInvader(int index)
        {
            invaders[index].Reset(hoogte);
            return invaders[index].Schiet();
        }

        public void BeweegInvaders()
        {
            foreach (var invader in invaders)
            {
                if(invader.LeeftNog())
                { 
                    invader.Beweeg(dobbelsteen.Next(1, invaderSnelheid));
                    if (invader.y <= 0)
                    {
                        invader.y = hoogte;
                        aantalSteden -= 1;
                    }
                    if (aantalSteden <= 0)
                        return;
                }
            }

            return;
        }
    }

    internal class Invader
    {
        public int InvaderLevens { get; set; }
        public int y;

        public Invader(int invaderLevens, int hoogte)
        {
            InvaderLevens = invaderLevens;
            this.y = hoogte;
        }

        public bool LeeftNog()
        {
            if(InvaderLevens > 0)
                return true;
            else
                return false;
        }

        public bool Schiet()
        {
            this.InvaderLevens -= 1;

            if(InvaderLevens == 0)
                return true;
            else
                return false;
        }

        public int Beweeg(int y)
        {
            this.y -= y;

            return this.y;
        }

        public void Reset(int y)
        {
            this.y = y;
        }
    }
}
