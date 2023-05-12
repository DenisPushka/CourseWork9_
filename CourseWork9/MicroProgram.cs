﻿namespace CourseWork9
{
    /// <summary>
    /// Микропрограмма.
    /// </summary>
    public class MicroProgram : AbstractMachine
    {
        /// <summary>
        /// Текущее состояние автомата.
        /// </summary>
        private byte _state;

        /// <summary>
        /// Форма отображеия.
        /// </summary>
        private readonly MainForm _form;

        /// <summary>
        /// Данные внесены в автомат.
        /// </summary>
        private bool _installData;

        public MicroProgram(MainForm form)
        {
            _state = 0;
            _form = form;
        }

        /// <summary>
        /// Автоматический режим.
        /// </summary>
        public void AutomaticMode()
        {
            while (Run)
            {
                Step();
            }
        }

        /// <summary>
        /// Такт.
        /// </summary>
        public override void Step()
        {
            switch (_state)
            {
                case 0:
                    if (X[0])
                    {
                        Operations[0]();
                        Operations[1]();
                        Operations[2]();
                        Operations[3]();

                        _state = 1;
                    }

                    break;
                case 1:
                    if (X[1])
                    {
                        Operations[17]();
                        _state = 9;
                    }
                    else if (X[2])
                    {
                        Operations[8]();
                        _state = 9;
                    }
                    else
                    {
                        Operations[4]();
                        _state = 2;
                    }

                    break;
                case 2:
                    if (X[3])
                    {
                        Operations[5]();
                        _state = 3;
                    }
                    else
                    {
                        Operations[17]();
                        _state = 9;
                    }

                    break;
                case 3:
                    Operations[6]();
                    Operations[7]();
                    Operations[8]();
                    Operations[9]();
                    _state = 4;
                    break;
                case 4:
                    Operations[4]();
                    _state = 5;
                    break;
                case 5:
                    if (X[3])
                    {
                        Operations[11]();
                        Operations[12]();
                    }
                    else
                    {
                        Operations[10]();
                    }

                    _state = 6;

                    break;
                case 6:
                    Operations[6]();
                    Operations[7]();
                    Operations[13]();
                    _state = 7;
                    break;
                case 7:
                    switch (X[4])
                    {
                        case true when X[5]:
                            Operations[14]();
                            _state = 8;
                            break;
                        case true when !X[5] && X[6]:
                            Operations[15]();
                            _state = 9;
                            break;
                        case true when !X[5] && !X[6]:
                            Operations[16]();
                            _state = 0;
                            break;
                        case false:
                            Operations[4]();
                            _state = 5;
                            break;
                    }

                    break;
                case 8:
                    if (X[6])
                    {
                        Operations[15]();
                        _state = 9;
                    }
                    else
                    {
                        Operations[16]();
                        _state = 0;
                    }

                    break;
                case 9:
                    Operations[16]();
                    _state = 0;
                    break;
            }

            // Отображение данных.
            _form.UpdateInfoRegister(Am, Bm, D, C, Count);
            _form.UpdateStateMemory(_state);
            LogicalDevice();
        }


        /// <summary>
        /// Внесение данные. Если данные еще не внесесы, то добавляются.
        /// </summary>
        /// <param name="a">Делимое А.</param>
        /// <param name="b">Делитель В.</param>
        public void InputData(ushort a, ushort b)
        {
            if (!_installData)
            {
                A = a;
                B = b;
                _installData = true;
            }
        }
        
        /// <summary>
        /// Сброс данных.
        /// </summary>
        public void Reset()
        {
            Run = true;
            _installData = false;
            A = 0;
            B = 0;
            Am = 0;
            Bm = 0;
            D = 0;
            C = 0;
            _state = 0;
        }
    }
}