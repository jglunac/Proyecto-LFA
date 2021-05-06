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

namespace Proyecto_LFA
{
    public partial class Form1 : Form
    {

        static STATE StateInitial = new STATE();
        static List<STATE> MTStates = new List<STATE>();
        static List<char> Alphabet = new List<char>();
        List<char> chars = new List<char>();
        int HeaderPos = 0;
        List<char> chararray = new List<char>();
        actualData data = new actualData();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddMT_Click(object sender, EventArgs e)
        {
            MTStates.Clear();
            Alphabet.Clear();
            chararray.Clear();
            HeaderPos = 0;
            actualData data = new actualData();
            StateInitial = new STATE();
            var RawMT = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\";
                openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFile.FileName;
                    var filestream = openFile.OpenFile();
                    using (StreamReader reader = new StreamReader(filestream))
                    {
                        RawMT = reader.ReadToEnd();
                    }
                }
            }

            try
            {
                string[] MT = RawMT.Split(new string[] { "\r\n" }, StringSplitOptions.None);


                /*

                    MT VISUALIZADA


                    MT[0]2
                    MT[1]1
                    MT[2]10
                    MT[3]1,_,2,_,d
                    MT[4]2,1,2,0,d
                    MT[5]2,0,2,1,d
                    MT[6]2,_,2,_,p
                */

                //GENERACIÓN DE ESTADOS


                int NoStates = Convert.ToInt32(MT[0]);
                StateInitial.Name = Convert.ToInt32(MT[1]);
                foreach (var item in MT[2])
                {
                    Alphabet.Add(item);
                }
                MTStates.Add(StateInitial);
                for (int i = 1; i <= NoStates; i++)
                {
                    if (i != StateInitial.Name)
                    {
                        STATE AuxState = new STATE();
                        AuxState.Name = i;
                        MTStates.Add(AuxState);
                    }
                }

                //GENERACIÓN DE TRANSICIONES

                for (int i = 3; i < MT.Length; i++)
                {
                    MT[i] = MT[i].Replace(",", string.Empty);
                    char[] Aux2 = MT[i].ToCharArray();
                    TRANSITION CurrentTransition = new TRANSITION();

                    foreach (var PState in MTStates)
                    {
                        //Asigna la transición correspondiente a cada estado
                        if (Convert.ToInt32(Aux2[0].ToString()) == PState.Name)
                        {
                            CurrentTransition.ToRead = Convert.ToChar(Aux2[1]);
                            foreach (var PState2 in MTStates)
                            {
                                if (PState2.Name == Convert.ToInt32(Aux2[2].ToString()))
                                {
                                    CurrentTransition.sTo = PState2;
                                    break;
                                }
                            }
                            CurrentTransition.ToWrite = Aux2[3];
                            char chr = char.ToLower(Aux2[4]);
                            if (chr != 'd' && chr != 'i' && chr != '0' && chr != 'p')
                            {
                                MessageBox.Show("¡Error en la transición! #" + (i - 3).ToString() + " línea " + i);
                                break;
                            }
                            else
                            {
                                CurrentTransition.Direction = char.ToLower(Aux2[4]);
                                PState.Transitions.Add(CurrentTransition);
                            }
                        }
                    }

                }

               
                MessageBox.Show("Máquina generada correctamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("¡No es una máquina válida!");
            }
        }

        private void SelectAuto_Click(object sender, EventArgs e)
        {
            bool OkAlphabet = true;
            if (MTStates.Count == 0)
            {
                MessageBox.Show("¡Primero ingresa una máquina válida!");
            }
            else
            {
                foreach (char item in Alphabet)
                {
                    bool exists = false;
                    
                    foreach (char item2 in txtWord.Text)
                    {
                        
                        if (item == item2)
                        {
                            exists = true;
                        }
                    }
                    if (exists != true)
                    {
                        OkAlphabet = false;
                        break;
                    }
                }
                if (OkAlphabet==true)
                {
                    PanelA.Enabled = true;
                    PanelA.Visible = true;
                }
                else
                {
                    MessageBox.Show("Revise su alfabeto.");
                }
            }
        }

        private void btnStartA_Click(object sender, EventArgs e)
        {
            chararray = txtWord.Text.ToCharArray().ToList();
            data = StateInitial.CheckTransitions(chararray, ref HeaderPos, false, false);
            switch (data.ErrCode)
            {
                case 1:
                    MessageBox.Show(data.Msg + " En: "
                        + " Posición del cabezal: " + HeaderPos.ToString()
                        + " Caracter a escribir: " + data.ToWrite.ToString()
                        + " Caracter a leer: " + data.ToRead.ToString()
                        + " Movimiento a realizar: " + data.Movement.ToString()
                        );
                    break;
                case 2:
                    MessageBox.Show(data.Msg);
                    string result = new string(chararray.ToArray());
                    lblCintaA.Text = result;
                    break;
                case 3:
                    MessageBox.Show(data.Msg);
                    lblHeaderPos.Text = HeaderPos.ToString();
                    string result2 = new string(chararray.ToArray());
                    lblCintaP.Text = result2.Remove(result2.Length - 1);
                    lblCintaA.Text = result2.Remove(result2.Length - 1);
                    btnSwitch.Visible = true;
                    btnSwitch.Enabled = true;
                    lblTransition.Text =
                        data.FromState.ToString() + " ," +
                        data.ToRead.ToString() + " ," +
                        data.sTo.ToString() + " ," +
                        data.ToWrite.ToString() + " ," +
                        data.Movement.ToString();
                    lblCurrentState.Text = data.FromState.ToString();
                        
                    break;
                case 4:
                    MessageBox.Show(data.Msg);
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MTStates.Clear();
            Alphabet.Clear();
            chararray.Clear();
            HeaderPos = 0;
            actualData data = new actualData();
            StateInitial = new STATE();
            lblCintaA.Text = "";
            PanelA.Visible = false;
            PanelA.Enabled = false;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            PanelP.Visible = true;
            PanelP.Enabled = true;
            PanelA.Enabled = false;
            PanelA.Visible = false;
        }
    }
}
