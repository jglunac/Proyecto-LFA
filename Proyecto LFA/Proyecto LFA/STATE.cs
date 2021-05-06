using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_LFA
{
    public class STATE
    {
		public int Name;
		public List<TRANSITION> Transitions = new List<TRANSITION>();

		public actualData CheckTransitions(List<char> currentTape, ref int position, bool inLoop, bool StepByStep)
		{
			char ReadChar = currentTape[position];
			foreach (var item in Transitions)
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
								data3.FromState = Name;
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
							data.FromState = Name;
							data.Movement = item.Direction;
							data.sTo = item.sTo.Name;
							data.ToRead = item.ToRead;
							data.ToWrite = item.ToWrite;
							data.Msg = "Proceso realizado correctamente";
							return data;
					}
					if (item.ToRead == item.ToWrite && item.sTo.Name == Name && !inLoop && (item.Direction=='0' || item.ToRead=='_'))
					{
						actualData data = new actualData();
						data.FromState = Name;
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
						data.FromState = Name;
						data.sTo = item.sTo.Name;
						data.ToRead = item.ToRead;
						data.ToWrite = item.ToWrite;
						return data;
					}
				}
			}
			actualData data1 = new actualData();
			data1.ErrCode = 4;
			data1.FromState = Name;
			data1.Msg = "No se ha encontrado ninguna transición con el caracter en la posición actual";
			return data1;
		}
	}
}
