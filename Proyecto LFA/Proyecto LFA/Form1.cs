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
        bool inLoop = false;
        static STATE CurrentState;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddMT_Click(object sender, EventArgs e)
        {
            PanelA.Visible = false;
            PanelP.Visible = false;
            PanelP.Enabled = false;
            PanelA.Enabled = false;
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

            //try
            //{
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
                List<string> Temp = MT.ToList();
                for(int i = 0; i<MT.Length; i++)
                {
                    if (MT[i]=="")
                    {
                        Temp.Remove(MT[i]);
                    }
                }

                MT = Temp.ToArray();
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
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("¡No es una máquina válida!");
            //    }
        }

        private void SelectAuto_Click(object sender, EventArgs e)
        {
            lblCintaA.Text = "";
            bool OkAlphabet = true;
            if (MTStates.Count == 0)
            {
                MessageBox.Show("¡Primero ingresa una máquina válida!");
            }
            else if (txtWord.Text == "")
            {
                MessageBox.Show("¡Primero ingresa una palabra!");
            }
            else
            {
                foreach (char item2 in txtWord.Text)
                {
                    bool exists = false;

                    if (item2 != '_')
                    {
                        foreach (char item in Alphabet)
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
                }
                if (OkAlphabet==true)
                {
                    btnAddMT.Enabled = false;
                    SelectAuto.Enabled = false;
                    btnStartP.Enabled = false;
                    PanelA.Visible = true;
                    PanelA.Enabled = true;
                    PanelP.Enabled = false;
                    PanelP.Visible = false;
                }
                else
                {
                    MessageBox.Show("Revise su alfabeto.");
                }
            }
        }

        private void btnStartA_Click(object sender, EventArgs e)
        {

            HeaderPos = 0;
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
                    lblHeaderPos.Text = HeaderPos.ToString();
                    lblCintaA.Text = result;
                    btnSwitch.Enabled = false;
                    btnStartP.Enabled = true;
                    SelectAuto.Enabled = true;
                    break;
                case 3:
                    MessageBox.Show(data.Msg);
                    lblHeaderPos.Text = HeaderPos.ToString();
                    string result2 = new string(chararray.ToArray());
                    lblCintaP.Text = result2;
                    lblCintaA.Text = result2;
                    btnSwitch.Visible = true;
                    btnSwitch.Enabled = true;
                    lblTransition.Text =
                        data.FromState.ToString() + " ," +
                        data.ToRead.ToString() + " ," +
                        data.sTo.ToString() + " ," +
                        data.ToWrite.ToString() + " ," +
                        data.Movement.ToString();
                    lblCurrentState.Text = data.sTo.ToString();
                    inLoop = true;
                    break;
                case 4:
                    MessageBox.Show(data.Msg);
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtWord.Clear();
            MTStates.Clear();
            Alphabet.Clear();
            chararray.Clear();
            HeaderPos = 0;
            actualData data = new actualData();
            StateInitial = new STATE();
            lblCintaA.Text = "";
            btnAddMT.Enabled = true;
            SelectAuto.Enabled = true;
            btnStartP.Enabled = true;
            PanelA.Visible = false;
            PanelA.Enabled = false;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            PanelA.Enabled = false;
            PanelA.Visible = false;
            PanelP.Visible = true;
            PanelP.Enabled = true;
            btnStop.Visible = true;
            foreach (var item in MTStates)
            {
                if (item.Name == data.sTo)
                {
                    CurrentState = item;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            data = CurrentState.CheckTransitions(chararray, ref HeaderPos, inLoop, true);
            foreach (var item in MTStates)
            {
                if (item.Name == data.sTo)
                {
                    CurrentState = item;
                }
            }


            switch (data.ErrCode)
            {
                case 0:
                    string ans2 = new string(chararray.ToArray());
                    lblCintaP.Text = ans2;
                    lblCintaA.Text = ans2;
                    lblTransition.Text =
                        data.FromState.ToString() + " ," +
                        data.ToRead.ToString() + " ," +
                        data.sTo.ToString() + " ," +
                        data.ToWrite.ToString() + " ," +
                        data.Movement.ToString();
                    lblCurrentState.Text = data.sTo.ToString();
                    lblHeaderPos.Text = HeaderPos.ToString();
                    break;
                case 1:
                    MessageBox.Show(data.Msg + " En: "
                        + " Posición del cabezal: " + HeaderPos.ToString()
                        + " Caracter a escribir: " + data.ToWrite.ToString()
                        + " Caracter a leer: " + data.ToRead.ToString()
                        + " Movimiento a realizar: " + data.Movement.ToString()
                        );
                    break;
                case 2:
                    string result = new string(chararray.ToArray());
                    lblCintaA.Text = result;
                    lblCintaP.Text = result;
                    lblTransition.Text =
                                data.FromState.ToString() + " ," +
                                data.ToRead.ToString() + " ," +
                                data.sTo.ToString() + " ," +
                                data.ToWrite.ToString() + " ," +
                                data.Movement.ToString();
                    btnStartP.Enabled = true;
                    SelectAuto.Enabled = true;
                    MessageBox.Show(data.Msg);
                    break;
                case 3:
                    MessageBox.Show(data.Msg);
                    lblHeaderPos.Text = HeaderPos.ToString();
                    string result2 = new string(chararray.ToArray());
                    lblCintaP.Text = result2;
                    lblCintaA.Text = result2;
                    btnSwitch.Visible = true;
                    btnSwitch.Enabled = true;
                    lblTransition.Text =
                        data.FromState.ToString() + " ," +
                        data.ToRead.ToString() + " ," +
                        data.sTo.ToString() + " ," +
                        data.ToWrite.ToString() + " ," +
                        data.Movement.ToString();
                    lblCurrentState.Text = data.FromState.ToString();
                    lblHeaderPos.Text = HeaderPos.ToString();
                    inLoop = true;
                    btnStop.Visible = true;
                  

                    break;
                case 4:
                    MessageBox.Show(data.Msg);
                    break;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtWord.Clear();
            MTStates.Clear();
            Alphabet.Clear();
            chararray.Clear();
            HeaderPos = 0;
            actualData data = new actualData();
            StateInitial = new STATE();
            lblCintaA.Text = "";
            btnAddMT.Enabled = true;
            SelectAuto.Enabled = true;
            btnStartP.Enabled = true;
            PanelA.Visible = false;
            PanelA.Enabled = false;
            PanelP.Enabled = false;
            PanelP.Visible = false;
        }

        private void btnStartP_Click(object sender, EventArgs e)
        {
            HeaderPos = 0;
            btnStop.Visible = false;
            btnAuto.Enabled = true;
            btnAuto.Visible = true;
            inLoop = false;
            bool OkAlphabet = true;
            if (MTStates.Count == 0)
            {
                MessageBox.Show("¡Primero ingresa una máquina válida!");
            }
            else if (txtWord.Text == "")
            {
                MessageBox.Show("¡Primero ingresa una palabra!");
            }
            else
            {
                foreach (char item2 in txtWord.Text)
                {
                    bool exists = false;

                    if (item2 != '_')
                    {
                        foreach (char item in Alphabet)
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
                }
                if (OkAlphabet == true)
                {
                    CurrentState = StateInitial;
                    btnAddMT.Enabled = false;
                    SelectAuto.Enabled = false;
                    btnStartP.Enabled = false;
                    PanelA.Enabled = false;
                    PanelA.Visible = false;
                    PanelP.Enabled = true;
                    PanelP.Visible = true;
                    chararray = txtWord.Text.ToCharArray().ToList();
                    string ans2 = new string(chararray.ToArray());
                    lblCintaP.Text = txtWord.Text;
                    lblTransition.Text = "Ninguna Transición Operada";
                    lblCurrentState.Text = StateInitial.Name.ToString();
                    lblHeaderPos.Text = HeaderPos.ToString();
                }
                else
                {
                    MessageBox.Show("Revise su alfabeto.");
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            lblCintaP.Text = "";
            lblCintaA.Text = "";
            lblTransition.Text = "";
            lblCurrentState.Text = "";
            btnStop.Visible = false;
            lblHeaderPos.Text = "";
            btnStartP.Enabled = true;
            SelectAuto.Enabled = true;
        }
    }
}
