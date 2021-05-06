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


        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddMT_Click(object sender, EventArgs e)
        {
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

                //DETECCIÓN DE ESTADO INICIAL
                //Encuentra el estado inicial
                foreach (var PState in MTStates)
                {
                    if (PState.Name == Convert.ToInt32(MT[0]))
                    {
                        StateInitial = PState;
                        break;
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
            PanelA.Enabled = true;
            PanelA.Visible = true;
        }

        private void btnStartA_Click(object sender, EventArgs e)
        {

        }


        private actualData CheckTransitions(List<char> currentTape, ref int position, bool inLoop, bool StepByStep, STATE ActualState)
        {
            char ReadChar = currentTape[position];
            foreach (var item in ActualState.Transitions)
            {
                if (item.ToRead == ReadChar)
                {
                    currentTape[position] = item.ToWrite;
                    switch (item.Direction)
                    {
                        //en caso Direction sea '0' position seguirá siendo la misma y así se enviará al próximo estado
                        case 'i':
                            if (position > 0) position--;
                            else
                            {
                                actualData data3 = new actualData();
                                data3.ErrCode = 1;
                                data3.Movement = item.Direction;
                                data3.sTo = item.sTo.Name;
                                data3.ToRead = item.ToRead;
                                data3.ToWrite = item.ToWrite;
                                data3.Msg = "Transición requiere movimiento a la izquierda en posición inicial";
                                return data3;
                            }
                            break;
                        case 'd':
                            if (position >= currentTape.Count - 1) currentTape.Add('_');
                            position++;
                            break;
                        case 'p':
                            actualData data = new actualData();
                            data.ErrCode = 2;
                            data.Movement = item.Direction;
                            data.sTo = item.sTo.Name;
                            data.ToRead = item.ToRead;
                            data.ToWrite = item.ToWrite;
                            data.Msg = "Proceso realizado correctamente";
                            return data;
                    }
                    if (item.ToRead == item.ToWrite && item.sTo.Name == ActualState.Name && !inLoop)
                    {
                        actualData data = new actualData();
                        data.ErrCode = 3;
                        data.Movement = item.Direction;
                        data.sTo = item.sTo.Name;
                        data.ToRead = item.ToRead;
                        data.ToWrite = item.ToWrite;
                        data.Msg = "Se ha detectado un loop ¿Desea continuar?";
                        return data;
                    }
                    if (!StepByStep)
                    {
                        return item.sTo.CheckTransitions(currentTape, ref position, inLoop, StepByStep);
                    }
                    else
                    {
                        actualData data = new actualData();
                        data.ErrCode = 0;
                        data.Movement = item.Direction;
                        data.sTo = item.sTo.Name;
                        data.ToRead = item.ToRead;
                        data.ToWrite = item.ToWrite;
                        return data;
                    }
                }
            }
            actualData data1 = new actualData();
            data1.ErrCode = 4;
            data1.Msg = "No se ha encontrado ninguna transición con el caracter en la posición actual";
            return data1;
        }
    }
}
